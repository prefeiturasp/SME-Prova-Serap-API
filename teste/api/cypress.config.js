const { defineConfig } = require('cypress')
const { cloudPlugin } = require('cypress-cloud/plugin')
const allureWriter = require('@shelex/cypress-allure-plugin/writer')
const dotenv = require('dotenv')
const cucumber = require('cypress-cucumber-preprocessor').default
const postgreSQL = require('cypress-postgresql')
const { Pool } = require('pg')

dotenv.config()

const dbConfig = {
  user: process.env.DB_USER,
  password: process.env.DB_PASSWORD,
  host: process.env.DB_HOST,
  database: process.env.DB_DATABASE,
}

module.exports = defineConfig({
  e2e: {

    env: {
      allure: true
    },

    async setupNodeEvents(on, config) {

      // Allure reporter
      allureWriter(on, config)

      // Cucumber preprocessor
      on('file:preprocessor', cucumber())

      // Cypress Cloud plugin
      config = await cloudPlugin(on, config)

      // PostgreSQL connection
      const pool = new Pool(dbConfig)
      const tasks = postgreSQL.loadDBPlugin(pool)

      on('task', {
        ...tasks
      })

      // Environment variables
      const envKeys = [
        'ALUNO_RA',
        'DATA_NASC',
        'DATA_NASC_INVALIDA',
        'DISPOSITIVO',
        'DISPOSITIVO_ID',
        'STATUS',
        'TIPO_DISPOSITIVO',
        'DATA_INICIO',
        'DATA_FIM',
        'PROVA_TAI_ID',
        'PROVA_TAI_ID_INVALIDO',
        'QUESTAO_ID',
        'QUESTAO_LEGADO_ID',
        'QUESTAO_LEGADO_ID_INVALIDO',
        'ALTERNATIVA_ID',
        'RESPOSTA',
        'DATA_HORA_RESPOSTA_TICKS',
        'TEMPO_RESPOSTA_ALUNO'
      ]

      const customVariable = Object.fromEntries(
        envKeys.map((key) => [key, process.env[key] ?? ''])
      )

      config.env = {
        ...config.env,
        ...customVariable,
      }

      return config
    },

    baseUrl: 'https://hom-serap-estudante.sme.prefeitura.sp.gov.br',

    supportFile: 'cypress/support/e2e.js',

    specPattern: [
      'cypress/e2e/**/*.feature'
    ],

    viewportWidth: 1600,
    viewportHeight: 1050,

    video: false,

    retries: {
      runMode: 2,
      openMode: 0,
    },

    screenshotOnRunFailure: false,
    chromeWebSecurity: false,
    experimentalRunAllSpecs: true,
    failOnStatusCode: false,

    defaultCommandTimeout: 60000,
    requestTimeout: 60000,
    execTimeout: 60000,
    pageLoadTimeout: 60000,

    waitForAnimations: true,
    animationDistanceThreshold: 5,
  },
})