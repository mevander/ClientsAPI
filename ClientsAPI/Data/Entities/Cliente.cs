using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClientsAPI.Data.Entities;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime DtNascimento { get; set; }

    public byte Status { get; set; }

    public DateTime DatInclusao { get; set; }

    public virtual ICollection<ClienteEndereco> ClienteEnderecos { get; set; } = new List<ClienteEndereco>();
}