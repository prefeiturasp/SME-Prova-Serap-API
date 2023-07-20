pipeline {
    
    environment {
        branchname =  env.BRANCH_NAME.toLowerCase()
        kubeconfig = getKubeconf(env.branchname)
        registryCredential = 'jenkins_registry'
    }
    agent {
      node { label 'agent-nodes' }
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
          when { anyOf { branch 'master'; branch 'main'; branch "story/*"; branch 'development'; branch 'develop'; branch 'release'; branch 'homolog'; branch 'homolog-r2';  } }
                    steps { 
                    script {
                      imagename1 = "registry.sme.prefeitura.sp.gov.br/${env.branchname}/sme-prova-serap-api"
                      dockerImage1 = docker.build(imagename1, "-f src/SME.Prova.Serap.Api/Dockerfile .")
                      docker.withRegistry( 'https://registry.sme.prefeitura.sp.gov.br', registryCredential ) {
              dockerImage1.push()
                }
            }
        }

        stage('Flyway') {
          when { anyOf { branch 'master'; branch 'main'; branch "story/*"; branch 'development'; branch 'develop'; branch 'release'; branch 'homolog'; branch 'homolog-r2';  } }
          agent { label 'master' }
          steps{
            withCredentials([string(credentialsId: "flyway_serapestudantes_${branchname}", variable: 'url')]) {
            checkout scm
            sh 'docker run --rm -v $(pwd)/scripts:/opt/scripts registry.sme.prefeitura.sp.gov.br/devops/flyway:5.2.4 -url=$url -locations="filesystem:/opt/scripts" -outOfOrder=true migrate'
            }
          }		
        }

        stage('Deploy') {
            when { anyOf { branch 'master'; branch 'main'; branch "story/*"; branch 'development'; branch 'develop'; branch 'release'; branch 'homolog'; branch 'homolog-r2';  } }
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
                                sh "kubectl rollout restart deployment/sme-prova-serap-api -n sme-serap-estudante"
                                sh('rm -f '+"$home"+'/.kube/config')
                        }   
            }
        }
    }
}
}
}
