/**
 * Page Object - Tela de Login do SERAp
 */
class LoginPage {
  visitar() {
    cy.visit(Cypress.env('WEB_BASE_URL'))
    return this
  }

  campoLogin() {
    return cy.get('input[name="login"], input#login, input[type="text"]').first()
  }

  campoSenha() {
    return cy.get('input[name="senha"], input#senha, input[type="password"]').first()
  }

  botaoEntrar() {
    return cy.contains('button, input[type="submit"]', /entrar/i)
  }

  preencherLogin(login) {
    this.campoLogin().clear().type(login)
    return this
  }

  preencherSenha(senha) {
    this.campoSenha().clear().type(senha, { log: false })
    return this
  }

  efetuarLogin(login, senha) {
    this.preencherLogin(login)
    this.preencherSenha(senha)
    this.botaoEntrar().click()
    return this
  }

  mensagemErro() {
    return cy.get('body').then(($body) => {
      const seletor = '.alert, .error, .mensagem-erro, [class*="error"]'
      return $body.find(seletor).length ? cy.get(seletor).first() : cy.contains(/usuário ou senha inválidos|credenciais inválidas/i)
    })
  }
}

export default new LoginPage()
