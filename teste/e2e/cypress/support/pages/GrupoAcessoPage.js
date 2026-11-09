/**
 * Page Object - Tela de Seleção de Grupo (exibida após o login SSO)
 */
class GrupoAcessoPage {
  titulo() {
    return cy.contains('Seleção de grupo')
  }

  grupo(nome) {
    this.titulo()
    return cy.contains(nome, { matchCase: false, timeout: 60000 })
  }

  selecionarAdministrador() {
    this.grupo('ADMINISTRADOR').click()
    return this
  }
}

export default new GrupoAcessoPage()
