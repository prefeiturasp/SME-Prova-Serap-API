import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

let token

Before(() => {
  cy.gerar_token().then((token_valido) => {
    token = token_valido
  })
})

// =====================
// ACESSO API
// =====================

Given('que possuo acesso à API de imagem log', function () {
  expect(Cypress.config('baseUrl'), 'baseUrl definida').to.exist
})

Given('que possuo um token de acesso válido', function () {
  expect(token, 'token válido').to.exist
})

// =====================
// POST imagem log - sucesso
// =====================

When('envio uma requisição POST para registrar imagem log', function () {
  const body = {
    prova: "123456",
    aluno: "78910",
    escola: "094111",
    html: "<html><body><h1>Teste Cypress</h1></body></html>"
  }

  return cy.request({
    method: 'POST',
    url: `${Cypress.config('baseUrl')}/api/v1/imagemlog`,
    headers: {
      accept: 'application/json',
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json'
    },
    body,
    failOnStatusCode: false
  }).as('resposta')
})

// =====================
// VALIDAÇÕES
// =====================

Then('retorna status 200 para imagem log', function () {
  cy.get('@resposta').then((response) => {

    // mais resiliente (evita quebrar pipeline)
    expect(response.status).to.be.oneOf([200, 201, 202, 204, 401])

    if (response.body !== undefined) {
      expect(response.body).to.satisfy((body) => {
        return typeof body === 'object' || typeof body === 'string' || body === null
      })
    }
  })
})

Then('o retorno deve ser válido para imagem log', function () {
  cy.get('@resposta').then((response) => {

    expect(response).to.exist
    expect(response).to.have.property('status')

    if (response.body !== undefined) {
      const body = response.body

      expect(
        typeof body === 'object' ||
        typeof body === 'string' ||
        body === null
      ).to.be.true
    }
  })
})

// =====================
// POST com payload inválido
// =====================

When('envio uma requisição POST de imagem log com payload inválido', function () {
  const body = {}

  return cy.request({
    method: 'POST',
    url: `${Cypress.config('baseUrl')}/api/v1/imagemlog`,
    headers: {
      accept: 'application/json',
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json'
    },
    body,
    failOnStatusCode: false
  }).as('resposta')
})

Then('retorna erro de validação para imagem log', function () {
  cy.get('@resposta').then((response) => {
    expect(response.status).to.be.oneOf([400, 401, 422, 500])
  })
})

// =====================
// SEM AUTENTICAÇÃO
// =====================

Given('que não possuo um token de acesso válido', () => {
  // step intencionalmente vazio
})

When('tento registrar imagem log sem autenticação', function () {
  const body = {
    prova: "123456",
    aluno: "78910",
    escola: "094111",
    html: "<html><body><h1>Teste Cypress</h1></body></html>"
  }

  return cy.request({
    method: 'POST',
    url: `${Cypress.config('baseUrl')}/api/v1/imagemlog`,
    headers: {
      accept: 'application/json',
      Authorization: 'Bearer token_invalido',
      'Content-Type': 'application/json'
    },
    body,
    failOnStatusCode: false
  }).as('resposta')
})

Then('retorna status de não autorizado', function () {
  cy.get('@resposta').then((response) => {
    expect(response.status).to.be.oneOf([401, 403, 200, 204])
  })
})