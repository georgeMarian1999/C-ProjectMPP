using System;
using System.Data;
using log4net;
using Problem11.ConnectionUtils;
using Problem11.Model;

namespace Problem11.Repositories
{
    public class EchipaRepository : IEchipaRepository
    {

        public static readonly ILog logger = LogManager.GetLogger("EchipaRepository");

        public EchipaRepository()
        {
            logger.Info("Se creeaza Repository Echipa");
        }

        public void delete(int id)
        {
            logger.InfoFormat("Se sterge echipa cu id-ul {0}", id);

            IDbConnection conn = DBUtils.getConnection();

            using (var com = conn.CreateCommand())
            {
                com.CommandText = "delete from Echipa where idEchipa=@id";

                IDbDataParameter paramId = com.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                com.Parameters.Add(paramId);
                var result = com.ExecuteNonQuery();
                if (result == 0)
                {
                    logger.Info("Eroare incercand sa se stearga echipa cu id-ul");
                    throw new Exception("Eroare la stergere");
                }
                logger.InfoFormat("S-a sters echipa cu id-ul {0}", id);
            }
        }

        public Echipa findOne(int id)
        {
            logger.InfoFormat("Se cauta echipa cu id-ul {0}", id);

            IDbConnection conn = DBUtils.getConnection();

            using (var com = conn.CreateCommand())
            {
                com.CommandText = "select idEchipa,nume from Echipa where idEchipa=@id";
                IDbDataParameter paramId = com.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                com.Parameters.Add(paramId);

                using (var Data = com.ExecuteReader())
                {
                    if (Data.Read())
                    {
                        int idEchipa = Data.GetInt32(0);
                        string nume = Data.GetString(1);

                        Echipa E = new Echipa(idEchipa, nume);
                        logger.InfoFormat("S-a gasit echipa cu id-ul {0}", E.Id);
                        return E;
                    }
                }
            }
            logger.InfoFormat("Nu s a gasit echipa cu id ul {0}", id);
            return null;
        }

        public void save(Echipa entity)
        {
            logger.InfoFormat("Se salveaza echipa cu id-il {0}", entity.Id);

            IDbConnection conn = DBUtils.getConnection();

            using (var com = conn.CreateCommand())
            {
                com.CommandText = "insert into Echipa values (@idEchipa,@nume)";

                IDbDataParameter paramIdEchipa = com.CreateParameter();
                paramIdEchipa.ParameterName = "@idEchipa";
                paramIdEchipa.Value = entity.Id;
                com.Parameters.Add(paramIdEchipa);

                IDbDataParameter paramNume = com.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                com.Parameters.Add(paramNume);


                var result = com.ExecuteNonQuery();
                if (result == 0)
                {
                    logger.Info("Error while adding");
                    throw new Exception("Nici o echipa adaugata!");
                }

            }
            logger.InfoFormat("A fost adaugata echipa cu id-ul {0}", entity.Id);
        }

        
    }
}
