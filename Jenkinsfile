pipeline {
    environment {
        branchname =  env.BRANCH_NAME.toLowerCase()
        kubeconfig = getKubeconf(env.branchname)
        registryCredential = 'jenkins_registry'
        namespace = "${env.branchname == 'release-r2' ? 'serap-estud-hom2' : env.branchname == 'release' ? 'serap-estud-hom' : env.branchname == 'development' ? 'serap-estud-dev' : 'sme-serap-estudante'}"
        
    }
    agent {
      node { label 'AGENT-NODES' }
    }
    options {
      buildDiscarder(logRotator(numToKeepStr: '20', artifactNumToKeepStr: '20'))
      disableConcurrentBuilds()
      skipDefaultCheckout()
    }

    stages {
        stage('CheckOut') {            
            steps { checkout scm }            
        }
        stage('Build') {
          when { anyOf { branch 'master'; branch 'main'; branch "story/*"; branch 'development'; branch 'develop'; branch 'release'; branch 'homolog'; branch 'homolog-r2'; branch 'release-r2';  } }
          steps { 
                    script {
                      imagename1 = "registry.sme.prefeitura.sp.gov.br/${env.branchname}/sme-prova-serap-api"
                      dockerImage1 = docker.build(imagename1, "-f src/SME.SERAp.Prova.Api/Dockerfile .")
                      docker.withRegistry( 'https://registry.sme.prefeitura.sp.gov.br', registryCredential ) {
              dockerImage1.push()
                }
            }
          }
        }

        stage('Flyway') {
          when { anyOf { branch 'master'; branch 'main'; branch "story/*"; branch 'development'; branch 'develop'; branch 'release'; branch 'homolog'; branch 'homolog-r2'; branch 'release-r2';  } }
          agent { label 'sme' }
          steps{
            withCredentials([string(credentialsId: "flyway_serapestudantes_${branchname}", variable: 'url')]) {
            checkout scm
            sh 'docker run --rm -v $(pwd)/scripts:/opt/scripts registry.sme.prefeitura.sp.gov.br/devops/flyway:5.2.4 -url=$url -locations="filesystem:/opt/scripts" -outOfOrder=true migrate'
            }
          }		
        }

        stage('Deploy') {
            when { anyOf { branch 'master'; branch 'main'; branch "story/*"; branch 'development'; branch 'develop'; branch 'release'; branch 'homolog'; branch 'homolog-r2'; branch 'release-r2';  } }
            steps {
                script {
                  if ( env.branchname == 'main' ||  env.branchname == 'master' ) {
                            withCredentials([string(credentialsId: 'aprovadores-prova-serap-itens', variable: 'aprovadores')]) {
                                timeout(time: 24, unit: "HOURS") {
                                    input message: 'Deseja realizar o deploy?', ok: 'SIM', submitter: "${aprovadores}"
                                }
                            }
                        }
                        withCredentials([file(credentialsId: "${kubeconfig}", variable: 'config')]){
                                sh('cp $config '+"$home"+'/.kube/config')
                                sh "kubectl rollout restart deployment/prova-serap-api -n ${namespace}"
                                sh('rm -f '+"$home"+'/.kube/config')
                        }   
                }
            }
        }
    }
}
def getKubeconf(branchName) {
    if("main".equals(branchName)) { return "config_prd"; }
    else if ("master".equals(branchName)) { return "config_prd"; }
    else if ("homolog".equals(branchName)) { return "config_release"; }
    else if ("release".equals(branchName)) { return "config_release"; }
    else if ("develop".equals(branchName)) { return "config_release"; }
    else if ("development".equals(branchName)) { return "config_release"; }
    else if ("release-r2".equals(branchName)) { return "config_release"; }
}
