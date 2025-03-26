using System.Windows.Input;

namespace ProjectPOB2421
{
    internal class RelayCommand : ICommand
    {
        private Action<object> loadTasks;
        private Func<object, bool> canLoadTasks;

        public RelayCommand(Action<object> loadTasks, Func<object, bool> canLoadTasks)
        {
            this.loadTasks = loadTasks;
            this.canLoadTasks = canLoadTasks;
        }
    }
}. 
using Microsoft.EntityFrameworkCore;
using static Prok4.rocvk.User;

var builder = WebApplication.CreateBuilder();

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
var builder = WebApplication.CreateBuilder();

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.Run();
var app = builder.Build();

namespace Prok4
{
    class rocvk
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; } = ""; // имя пользователя
            public int Age { get; set; } // возраст пользователя
            public class ApplicationContext : DbContext
            {
                public DbSet<User> Users { get; set; } = null!;
                public ApplicationContext(DbContextOptions<ApplicationContext> options)
                    : base(options)
                {
                    Database.EnsureCreated();   // создаем базу данных при первом обращении
                }
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<User>().HasData(
                            new User { Id = 1, Name = "Tom", Age = 37 },
                            new User { Id = 2, Name = "Bob", Age = 41 },
                            new User { Id = 3, Name = "Sam", Age = 24 }
                    );
                }

            }
        }
    }
}