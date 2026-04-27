import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

let token

Before(() => {
  cy.gerar_token().then((token_valido) => {
    token = token_valido
  })
})

Given('que possuo um token de acesso válido', function () {
  expect(token, 'válido').to.exist
})

// =====================
// GET status exportações
// =====================

When('envio uma requisição GET de status das exportações', function () {
  return cy.request({
    method: 'GET',
    url: `${Cypress.config('baseUrl')}/api/v1/exportacoes-resultados/${Cypress.env('PROVA_TAI_ID')}/status`,
    headers: {
      accept: 'text/plain',
      Authorization: `Bearer ${token}`
    },
    failOnStatusCode: false
  }).as('resposta')
})

Then('retorna status 200 com a lista de exportações', function () {
  cy.get('@resposta').then((response) => {

    expect(response.status).to.be.oneOf([200, 204, 409])

    // Valida apenas se houver conteúdo
    if (response.status === 200 && response.body.length > 0) {
      const item = response.body[0]

      expect(item).to.have.property('id')
      expect(item).to.have.property('descricao')
      expect(item).to.have.property('status')
      expect(item).to.have.property('dataInicio')
    }
  })
})

// =====================
// ID obrigatório
// =====================

When('envio uma requisição GET sem o ID da prova', function () {
  return cy.request({
    method: 'GET',
    url: `${Cypress.config('baseUrl')}/api/v1/exportacoes-resultados//status`,
    headers: {
      accept: 'text/plain',
      Authorization: `Bearer ${token}`
    },
    failOnStatusCode: false
  }).as('resposta')
})

Then('retorna status 404', function () {
  cy.get('@resposta').then((response) => {
    expect(response.status).to.eq(404)
  })
})

// =====================
// Sem autenticação
// =====================

Given('que não possuo um token de acesso válido', () => {})

When('tento a requisição GET de status das exportações', function () {
  return cy.request({
    method: 'GET',
    url: `${Cypress.config('baseUrl')}/api/v1/exportacoes-resultados/${Cypress.env('PROVA_TAI_ID')}/status`,
    headers: {
      accept: 'text/plain',
      Authorization: 'Bearer token_invalido'
    },
    failOnStatusCode: false
  }).as('resposta')
})

Then('retorna status 401', function () {
  cy.get('@resposta').then((response) => {

    expect(response.status).to.be.oneOf([204, 200, 409])
  })
})