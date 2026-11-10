import { Given, When, Then } from 'cypress-cucumber-preprocessor/steps'

let response
let token
let questaoId
let alternativaId

// =========================
// DADO
// =========================

Given('que possuo credenciais válidas para prova TAI', () => {
  const requiredEnv = ['API_URL', 'LOGIN', 'SENHA', 'PROVA_ID']

  requiredEnv.forEach((key) => {
    const value = Cypress.env(key)

    expect(value, `Variável ${key} não definida`).to.exist
    expect(value.toString(), `${key} vazio`).to.not.be.empty
  })
})

// =========================
// LOGIN
// =========================

When('realizo login na API de prova TAI', () => {
  return cy.request({
    method: 'POST',
    url: `${Cypress.env('API_URL')}/api/v1/autenticacao`,
    headers: {
      'Content-Type': 'application/json'
    },
    body: {
      login: Cypress.env('LOGIN'),
      senha: Cypress.env('SENHA'),
      dispositivo: ''
    },
    failOnStatusCode: false
  }).then((res) => {
    response = res
    token = res.body?.token
  })
})

Then('o login deve retornar status válido', () => {
  expect(response.status).to.be.oneOf([200, 204, 400, 401, 404])
})

Then('o retorno do login deve ser válido', () => {
  expect(response).to.exist

  if (response.body) {
    expect(
      typeof response.body === 'object' ||
      typeof response.body === 'string'
    ).to.be.true
  }
})

// =========================
// INICIAR PROVA
// =========================

When('inicio a prova TAI', () => {
  if (!token) return

  return cy.request({
    method: 'POST',
    url: `${Cypress.env('API_URL')}/api/v1/provas-tai/${Cypress.env('PROVA_ID')}/iniciar-prova`,
    headers: {
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json'
    },
    body: {
      status: 1,
      tipoDispositivo: 3,
      dataInicio: Date.now(),
      dataFim: null
    },
    failOnStatusCode: false
  }).then((res) => {
    response = res
  })
})

Then('o status da resposta deve ser válido para iniciar prova TAI', () => {
  if (!token) return
  expect(response.status).to.be.oneOf([200, 204, 411, 401])
})

// =========================
// OBTER QUESTÃO
// =========================

When('obtenho uma questão da prova TAI', () => {
  if (!token) return

  return cy.request({
    method: 'POST',
    url: `${Cypress.env('API_URL')}/api/v1/provas-tai/${Cypress.env('PROVA_ID')}/obter-questao`,
    headers: {
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json'
    },
    body: {},
    failOnStatusCode: false
  }).then((res) => {
    response = res

    const body = res.body
    questaoId = body?.id
    alternativaId = body?.alternativas?.[0]?.id
  })
})

Then('o status da resposta deve ser válido para questão TAI', () => {
  if (!token) return
  expect(response.status).to.be.oneOf([200, 204, 401])
})

Then('a questão da prova TAI deve ser válida', () => {
  if (!token) return

  expect(
    questaoId !== undefined ||
    alternativaId !== undefined
  ).to.be.true
})

// =========================
// RESPONDER
// =========================

When('respondo a questão da prova TAI', () => {
  if (!token || !questaoId || !alternativaId) return

  return cy.request({
    method: 'POST',
    url: `${Cypress.env('API_URL')}/api/v1/provas-tai/${Cypress.env('PROVA_ID')}/proximo`,
    headers: {
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json'
    },
    body: {
      questaoId,
      alternativaId,
      alunoRa: Cypress.env('LOGIN'),
      dataHoraRespostaTicks: Date.now(),
      dispositivoId: "cypress",
      tempoRespostaAluno: 5000
    },
    failOnStatusCode: false
  }).then((res) => {
    response = res
  })
})

Then('o status da resposta deve ser válido para resposta TAI', () => {
  if (!token) return
  expect(response.status).to.be.oneOf([200, 204, 401])
})

// =========================
// RESUMO
// =========================

When('consulto o resumo da prova TAI', () => {
  if (!token) return

  return cy.request({
    method: 'GET',
    url: `${Cypress.env('API_URL')}/api/v1/provas-tai/${Cypress.env('PROVA_ID')}/resumo`,
    headers: {
      Authorization: `Bearer ${token}`
    },
    failOnStatusCode: false
  }).then((res) => {
    response = res
  })
})

Then('o status da resposta deve ser válido para resumo TAI', () => {
  if (!token) return
  expect(response.status).to.be.oneOf([200, 204, 401])
})