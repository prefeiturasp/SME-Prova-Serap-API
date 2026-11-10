import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

let token

Before(() => {
  cy.gerar_token().then((token_valido) => {
    token = token_valido
  })
})

// =====================
// GIVEN
// =====================

Given('que possuo um token de acesso válido', function () {
  expect(token, 'valido').to.exist
})

Given('que não possuo um token de acesso valido', () => {})

// =====================
// WHEN
// =====================

// GET resumo prova TAI (com token válido)
When('envio uma requisição GET de resumo prova TAI', function () { 
  return cy.request({
    method: 'GET',
    url: `${Cypress.config('baseUrl')}/api/v1/provas-tai/${Cypress.env('PROVA_TAI_ID')}/resumo`,
    headers: {
      accept: 'text/plain',
      Authorization: `Bearer ${token}`
    },
    failOnStatusCode: false
  }).as('resposta')
})

// GET sem ID
When('envio uma requisição GET sem o ID da prova', function () { 
  return cy.request({
    method: 'GET',
    url: `${Cypress.config('baseUrl')}/api/v1/provas-tai//resumo`,
    headers: {
      accept: 'text/plain',
      Authorization: `Bearer ${token}`
    },
    failOnStatusCode: false
  }).as('resposta')
})

// GET sem autenticação / token inválido
When('tento a requisição GET de resumo da prova TAI', function () { 
  return cy.request({
    method: 'GET',
    url: `${Cypress.config('baseUrl')}/api/v1/provas-tai/${Cypress.env('PROVA_TAI_ID')}/resumo`,
    headers: {
      accept: 'application/json',
      Authorization: 'Bearer token_invalido'
    },
    failOnStatusCode: false
  }).as('resposta')
})

// =====================
// THEN
// =====================

// Sucesso
Then('retorna status 200', function () {
  cy.get('@resposta').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// ID obrigatório
Then('retorna status 404', function () {
  cy.get('@resposta').then((response) => {
    expect(response.status).to.eq(404)
  })
})

// Sem autenticação
Then('não verifica o status 401', function () {
  cy.get('@resposta').then((response) => {
    expect(response.status).to.eq(401)
  })
})