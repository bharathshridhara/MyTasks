using AutoMapper;
using Microsoft.Owin;
using MyTasks.Data;
using MyTasks.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTasks.Startup))]
namespace MyTasks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Mapper.Initialize(config => config.CreateMap(typeof(ToDo), typeof(ToDoViewModels)).ReverseMap());
        }
    }
}
