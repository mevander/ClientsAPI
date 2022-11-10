using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClientsAPI.Data.Entities;

public partial class ClienteEndereco
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public string Logradouro { get; set; }

    public string Cep { get; set; }

    public string Uf { get; set; }

    public string Cidade { get; set; }

    public string Bairro { get; set; }

    public byte Status { get; set; }

    public DateTime DatInclusao { get; set; }

    [JsonIgnore]
    public virtual Cliente IdClienteNavigation { get; set; }
}