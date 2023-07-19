pipeline {
    agent any

    environment {
        REGISTRY_HOST = credentials('REGISTRY_HOST')
        REGISTRY_USER = credentials('REGISTRY_USER')
        REGISTRY_PWD = credentials('REGISTRY_PWD')
        USER_DB = credentials('USER_DB')
        PASSWORD_DB = credentials('PASSWORD_DB')
        URL_DB = credentials('URL_DB')
        RANCHER_URL = credentials('RANCHER_URL')
        RANCHER_TOKEN = credentials('RANCHER_TOKEN')
    }

    stages {
        stage('Build Docker Image') {
            when {
                anyOf {
                    branch 'main'
                    branch 'master'
                    branch 'release'
                }
                not {
                    changeset "**/.github/workflows/**"
                }
            }
            steps {
                checkout scm

                script {
                    docker.withRegistry(REGISTRY_HOST, REGISTRY_USER, REGISTRY_PWD) {
                        def imageName = "${REGISTRY_HOST}/${env.GITHUB_REF.tokenize('/').last()}/sme-prova-serap-api"
                        docker.build(imageName, "-f src/SME.SERAp.Prova.Api/Dockerfile .")
                        docker.withRegistry(REGISTRY_HOST, REGISTRY_USER, REGISTRY_PWD) {
                            docker.push(imageName)
                        }
                    }
                }
            }
        }

        stage('Flyway Release') {
            when {
                branch 'release'
            }
            steps {
                checkout scm

                withDockerContainer(image: 'boxfuse/flyway:5.2.4', volumes: ["$PWD/scripts:/flyway/sql"]) {
                    sh "flyway -user=${USER_DB} -password=${PASSWORD_DB} -url=${URL_DB} -outOfOrder=true migrate"
                }
            }
        }

        stage('Deploy Release') {
            when {
                branch 'release'
            }
            steps {
                script {
                    // Implement your deployment logic here, e.g., using 'kubectl' or 'helm' to deploy to Kubernetes
                    // Use RANCHER_URL and RANCHER_TOKEN for authentication
                }
            }
        }

        stage('Flyway Master') {
            when {
                branch 'master'
            }
            steps {
                checkout scm

                withDockerContainer(image: 'boxfuse/flyway:5.2.4', volumes: ["$PWD/scripts:/flyway/sql"]) {
                    sh "flyway -user=${USER_DB} -password=${PASSWORD_DB} -url=${URL_DB} -outOfOrder=true migrate"
                }
            }
        }

        stage('Deploy Master') {
            when {
                branch 'master'
            }
            steps {
                script {
                    // Implement your deployment logic here, e.g., using 'kubectl' or 'helm' to deploy to Kubernetes
                    // Use RANCHER_URL and RANCHER_TOKEN for authentication
                }
            }
        }
    }
}
