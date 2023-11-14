using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Factory
{
    public static class FactoryDAL
    {
        readonly static string repository;

        public static IGenericRepository <Cliente> ClienteRepository { get; private set; }
        public static IGenericRepository <Vendedor> VendedorRepository { get; private set; }

        static FactoryDAL()
        {
            repository = ConfigurationManager.AppSettings["Repository"].ToString();

            ClienteRepository = (IGenericRepository<Cliente>) Activator.CreateInstance
                                (Type.GetType(repository + ".ClienteRepository"));
            VendedorRepository = (IGenericRepository<Vendedor>)Activator.CreateInstance
                                 (Type.GetType(repository + ".VendedorRepository"));
        }
    }
}
