using ClientsAPI.Data;
using Microsoft.EntityFrameworkCore;
using ClientsAPI.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace ClientsAPI.Endpoints
{
	public static class ClientsEndpoints
	{
		public static void MapClientEndpoints(this WebApplication app)
		{
			app.MapGet("/clients", List).Produces<Cliente>(StatusCodes.Status200OK);
			app.MapGet("/clients/{id}", Get).Produces<Cliente>(StatusCodes.Status200OK);
			app.MapPost("/clients", Create).Accepts<Cliente>("application/json");
			app.MapPut("/clients", Update).Accepts<Cliente>("application/json");
            app.MapDelete("/clients/{id}", Delete);
		}

		public static async Task<IResult> List(ClientsContextDb db)
		{
			var result = await db.Clientes.Include(x => x.ClienteEnderecos).ToListAsync();
			return Results.Ok(result);
		}

		public static async Task<IResult> Get(ClientsContextDb db, int id)
		{
			return await db.Clientes.Include(x => x.ClienteEnderecos).SingleOrDefaultAsync(x => x.Id == id) is Cliente cliente
				? Results.Ok(cliente)
				: Results.NotFound();
		}

		public static async Task<IResult> Create(ClientsContextDb db, Cliente cliente)
		{
			cliente.DatInclusao = DateTime.UtcNow;
			db.Clientes.Add(cliente);
	        await db.SaveChangesAsync();

			return Results.Created($"/clients/{cliente.Id}", cliente);
		}

		public static async Task<IResult> Update(ClientsContextDb db, Cliente updatedClient)
		{
			var client = await db.Clientes.FindAsync(updatedClient.Id);

			if (client is null) return Results.NotFound();

			client.Nome = updatedClient.Nome;
			client.DtNascimento = updatedClient.DtNascimento;
			client.Status = updatedClient.Status;

            foreach (var updatedaddress in updatedClient.ClienteEnderecos)
            {
                var address = await db.ClienteEnderecos.FindAsync(updatedaddress.Id);

				if (address is null)
				{
					updatedaddress.IdCliente = updatedClient.Id;
					updatedaddress.DatInclusao = DateTime.UtcNow;
					db.ClienteEnderecos.Add(updatedaddress);

                }
				else {
					address.Status = updatedaddress.Status;
					address.Cep = updatedaddress.Cep;
					address.Logradouro = updatedaddress.Logradouro;
					address.Bairro = updatedaddress.Bairro;
					address.Cidade = updatedaddress.Cidade;
				}

            }

            await db.SaveChangesAsync();

			return Results.Ok();
		}

		public static async Task<IResult> Delete(ClientsContextDb db, int id)
		{
			if (await db.Clientes.Include(x => x.ClienteEnderecos).SingleOrDefaultAsync(x => x.Id == id) is Cliente client)
			{
				db.Clientes.Remove(client);
				await db.SaveChangesAsync();
				return Results.NoContent();
			}

			return Results.NotFound();
		}
	}
}
