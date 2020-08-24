using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Webmotors.Challenge.Domain.Dto.Request;
using Webmotors.Challenge.Domain.Entities;
using Webmotors.Challenge.Domain.Interfaces.Repositories;

namespace Webmotors.Challenge.Infra.Data
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly string _connection;

        public AnuncioRepository(string connection)
        {
            _connection = connection;
        }

        public IEnumerable<Anuncio> Get()
        {
            string query = @"SELECT * FROM tb_AnuncioWebmotors with(nolock)";

            using (var sqlConnection = new SqlConnection(_connection))
            {
                return sqlConnection.Query<Anuncio>(query, new { });
            }
        }
        public Anuncio Get(int id)
        {
            string query = @"SELECT * FROM tb_AnuncioWebmotors with(nolock) where Id=@Id";

            using (var sqlConnection = new SqlConnection(_connection))
            {
                return sqlConnection.QueryFirstOrDefault<Anuncio>(query, new { id });
            }
        }

        public int Add(AnuncioRequest anuncio)
        {
            string query = @"
                INSERT INTO tb_AnuncioWebmotors (
                    Marca,
                    Modelo,
                    Versao,
                    Ano,
                    Quilometragem,
                    Observacao
                )
                VALUES (
	                @Marca,
	                @Modelo,
	                @Versao,
	                @Ano,
	                @Quilometragem,
	                @Observacao
                );

                SELECT SCOPE_IDENTITY();
            ";

            using (var sqlConnection = new SqlConnection(_connection))
            {
                return sqlConnection.ExecuteScalar<int>(
                    query,
                    new
                    {
                        anuncio.Marca,
                        anuncio.Modelo,
                        anuncio.Versao,
                        anuncio.Ano,
                        anuncio.Quilometragem,
                        anuncio.Observacao
                    }
                );
            }

        }

        public int Update(int id, AnuncioRequest anuncio)
        {
            string query = @"
                UPDATE tb_AnuncioWebmotors
                SET Marca = @Marca,
                    Modelo = @Modelo,
                    Versao = @Versao,
                    Ano = @Ano,
                    Quilometragem = @Quilometragem,
                    Observacao = @Observacao
                WHERE ID = @ID";

            using (var sqlConnection = new SqlConnection(_connection))
            {
                return sqlConnection.ExecuteScalar<int>(
                    query,
                    new
                    {
                        anuncio.Marca,
                        anuncio.Modelo,
                        anuncio.Versao,
                        anuncio.Ano,
                        anuncio.Quilometragem,
                        anuncio.Observacao,
                        id
                    }
                );
            }
        }
        public async Task<int> Delete(int id)
        {
            string query = @"
                DELETE FROM tb_AnuncioWebmotors
                WHERE ID = @ID";

            using (var sqlConnection = new SqlConnection(_connection))
            {
                return await sqlConnection.ExecuteScalarAsync<int>(
                    query,
                    new { id }
                );
            }
        }
    }
}
