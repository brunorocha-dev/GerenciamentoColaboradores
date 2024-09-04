using ClosedXML.Excel;
using GerenciadorColaboradores.Data;
using GerenciadorColaboradores.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace GerenciadorColaboradores.Controllers
{
    public class GerenciadorController : Controller
    {
        readonly private ApplicationDbContext _db;
        public GerenciadorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ColaboradorModel> gerenciamentos = _db.Gerenciador;

            return View(gerenciamentos);
        }


        [HttpGet]
        public IActionResult Registrar() 
        {
            return View();
        }
        // criando o editar, alterando os registros
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            // criando praticamente um select com where
            ColaboradorModel colaborador = _db.Gerenciador.FirstOrDefault(x => x.Id == id);

            if (colaborador == null) 
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // Excluir = mesmo coisa de editar
        [HttpGet]
        public IActionResult Excluir(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ColaboradorModel colaborador = _db.Gerenciador.FirstOrDefault(x => x.Id == id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }
        // Meu Exportar
        public IActionResult Exportar() 
        {
            var dados = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados de Colaboradores");

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "Registros.xls");
                }
            }
        }

        private DataTable GetDados() 
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados do Relatório";
            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Matricula", typeof(int));
            dataTable.Columns.Add("Salario", typeof(decimal));
            dataTable.Columns.Add("Cargo", typeof(string));
            dataTable.Columns.Add("RegistroEntrada", typeof(DateTime));
            dataTable.Columns.Add("RegistroSaida", typeof(DateTime));

            var dados = _db.Gerenciador.ToList();

            if (dados.Count > 0) 
            {
                dados.ForEach(colaborador =>
                {
                    dataTable.Rows.Add(colaborador.Nome, colaborador.Matricula, colaborador.Salario, colaborador.Cargo, colaborador.RegistroEntrada, colaborador.RegistroSaida);
                });
            }

            return dataTable;
        }

        [HttpPost]
        public IActionResult Registrar(ColaboradorModel gerenciamentos)
        {

            if (ModelState.IsValid) 
            { 
                _db.Gerenciador.Add(gerenciamentos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Registro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar o registro!";

            return View();

        }

        [HttpPost]
        public IActionResult Editar(ColaboradorModel gerenciamentos) 
        {
            if (ModelState.IsValid) 
            {
                var gerenciadorDB = _db.Gerenciador.Find(gerenciamentos.Id);

                gerenciadorDB.Nome = gerenciamentos.Nome;
                gerenciadorDB.Matricula = gerenciamentos.Matricula;
                gerenciadorDB.Cargo = gerenciamentos.Cargo;
                gerenciadorDB.Salario = gerenciamentos.Salario;

                _db.Gerenciador.Update(gerenciadorDB);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";

            return View(gerenciamentos);
        }
        
        [HttpPost]
        public IActionResult Excluir(ColaboradorModel gerenciamentos) 
        { 
            if (gerenciamentos == null)
            {
                return NotFound();
            }

            _db.Gerenciador.Remove(gerenciamentos);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Remoção realizado com sucesso!";

            return RedirectToAction("Index");
        }

    }
}