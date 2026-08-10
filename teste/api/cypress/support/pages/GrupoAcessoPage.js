/**
 * Page Object - Tela de seleção de grupo de acesso (exibida após o login)
 */
class GrupoAcessoPage {
  titulo() {
    return cy.contains(/qual grupo você deseja acessar/i)
  }

  grupo(nome) {
    return cy.contains(nome)
  }

  selecionarAdministrador() {
    this.grupo(/administrador/i).click()
    return this
  }

  /**
   * A tela de seleção de grupo só é exibida quando o usuário possui
   * mais de um grupo de acesso disponível. Caso o sistema já tenha ido
   * direto para a home (ex.: sessão anterior já com grupo definido),
   * este passo é ignorado.
   */
  selecionarAdministradorSeExibido() {
    cy.get('body', { timeout: 15000 }).then(($body) => {
      const jaEstaNaHome = $body.text().includes('Bem-vindo,')
      if (jaEstaNaHome) {
        return
      }
      this.selecionarAdministrador()
    })
    return this
  }
}

export default new GrupoAcessoPage()
