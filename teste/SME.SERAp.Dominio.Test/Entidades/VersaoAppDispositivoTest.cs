using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

public class VersaoAppDispositivoTest
{
    private readonly DateTime _atualizadoEm = new DateTime(2024, 5, 20);

    [Fact]
    public void Deve_Criar_VersaoAppDispositivo_Com_Construtor_Parametros()
    {
        var antes = DateTime.Now;
        var versao = new VersaoAppDispositivo(12, "v1.2.0", "IMEI-001", _atualizadoEm, "device-abc");
        var depois = DateTime.Now;

        Assert.Equal(12, versao.VersaoCodigo);
        Assert.Equal("v1.2.0", versao.VersaoDescricao);
        Assert.Equal("IMEI-001", versao.DispositivoImei);
        Assert.Equal(_atualizadoEm, versao.AtualizadoEm);
        Assert.Equal("device-abc", versao.DispositivoId);
        Assert.InRange(versao.CriadoEm, antes, depois);
    }

    [Fact]
    public void Deve_Definir_CriadoEm_Automaticamente_No_Construtor()
    {
        var antes = DateTime.Now;
        var versao = new VersaoAppDispositivo(1, "v1.0", "IMEI", _atualizadoEm, "dev");
        var depois = DateTime.Now;

        Assert.InRange(versao.CriadoEm, antes, depois);
    }

    [Fact]
    public void Deve_Criar_VersaoAppDispositivo_Com_VersaoDescricao_Nula()
    {
        var versao = new VersaoAppDispositivo(1, null, "IMEI", _atualizadoEm, "dev");

        Assert.Null(versao.VersaoDescricao);
    }

    [Fact]
    public void Deve_Criar_VersaoAppDispositivo_Com_DispositivoImei_Nulo()
    {
        var versao = new VersaoAppDispositivo(1, "v1.0", null, _atualizadoEm, "dev");

        Assert.Null(versao.DispositivoImei);
    }

    [Fact]
    public void Deve_Criar_VersaoAppDispositivo_Com_DispositivoId_Nulo()
    {
        var versao = new VersaoAppDispositivo(1, "v1.0", "IMEI", _atualizadoEm, null);

        Assert.Null(versao.DispositivoId);
    }

    [Fact]
    public void Deve_Criar_VersaoAppDispositivo_Com_VersaoCodigo_Zero()
    {
        var versao = new VersaoAppDispositivo(0, "v0.0", "IMEI", _atualizadoEm, "dev");

        Assert.Equal(0, versao.VersaoCodigo);
    }

    [Fact]
    public void Deve_Criar_VersaoAppDispositivo_Com_AtualizadoEm_Especifico()
    {
        var data = new DateTime(2024, 12, 31);
        var versao = new VersaoAppDispositivo(5, "v5.0", "IMEI", data, "dev");

        Assert.Equal(data, versao.AtualizadoEm);
    }

    [Fact]
    public void Deve_Alterar_AtualizadoEm_Apos_Criacao()
    {
        var versao = new VersaoAppDispositivo(1, "v1.0", "IMEI", _atualizadoEm, "dev");
        var novaData = new DateTime(2025, 1, 1);
        versao.AtualizadoEm = novaData;

        Assert.Equal(novaData, versao.AtualizadoEm);
    }

    [Fact]
    public void Deve_Criar_VersaoAppDispositivo_Herdando_EntidadeBase()
    {
        var versao = new VersaoAppDispositivo(1, "v1.0", "IMEI", _atualizadoEm, "dev");
        versao.Id = 44;

        Assert.Equal(44, versao.Id);
    }
}