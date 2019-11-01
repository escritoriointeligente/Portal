using EI.Portal.Companies;
using EI.Portal.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Portal.Tests.Companies
{
    public class TestCompanyBuilder
    {
        private readonly PortalDbContext _context;

        public TestCompanyBuilder(PortalDbContext context)
        {
            _context = context;
        }


        public Guid AddCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company.Id;
        }

        public Guid AddEscritorioInteligente()
        {
            var ei = new Company("09.385.712/0001-40", "Escritório Inteligente", Portal.Companies.Type.EI);
            return AddCompany(ei);
        }

        public Guid AddAccounting()
        {
            var eiId = AddEscritorioInteligente();

            var accounting = new Company("50035781000128", "ORGANIZACAO CONTABIL CAMPANHOLA SS LTDA. - EPP", Portal.Companies.Type.Accounting, null, eiId);
            return AddCompany(accounting);
        }

        public void AddFinal()
        {
            var accountingId = AddAccounting();

            var final = new Company("04495771000158", "AVEC - JUNDIAI DISTRIBUIDORA DE PRODUTOS ALIMENTICIOS EIRELI", Portal.Companies.Type.Final, null, accountingId);
            AddCompany(final);
        }

        public void Build()
        {
            AddFinal();
        }
    }
}
