using CadastroDeUsuario.Data;
using CadastroDeUsuario.Models;

namespace CadastroDeUsuario.Controller
{
    internal class UsuarioController 
    {
        private AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar() 
        {
            #region Perdi dados
            Console.WriteLine("Primeiro Nome: ");
            string primeiroNome = Console.ReadLine();

            Console.WriteLine("SobreNome: ");
            string Sobrenome = Console.ReadLine();
            Console.WriteLine("Data de Nascimento: ");
            DateOnly nascimento = DateOnly.Parse(Console.ReadLine());
            #endregion Fim
            
            var novoUsuario = new Usuario()
            { 
                DataNascimento = nascimento,
                PrimeiroNome = primeiroNome,
                Sobrenome = Sobrenome
            };
                _context.Usuarios.Add(novoUsuario); 
                _context.SaveChanges();
            Console.WriteLine("Usuário cadastrado");
            Console.ReadKey();
        }
        

        public void Listar()
        {
            var usuarios = _context.Usuarios.ToList();

            if (usuarios.Count() ==0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
            }
            else
            { 
                foreach (var usuario in usuarios) 
                {
                    Console.Write($"ID: {usuario.Id} | Nome: {usuario.PrimeiroNome}");
                }
            }
            Console.Write("\n Pressione qualquer tecla para voltar.");
            Console.ReadKey();
        }
    }
}
