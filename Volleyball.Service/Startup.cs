using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volleyball.Service.Entities;
using Volleyball.Service.Models;
using Volleyball.Service.Services.Interfaces;
using Volleyball.Service.Services.Repositories;

namespace Volleyball.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VolleyballContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // register the repository
            services.AddScoped<ILeagueRepository, LeagueRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<PlayerDto, Player>();
                cfg.CreateMap<LeagueForCreationDto, League>();
                cfg.CreateMap<League, LeagueDto>();
                cfg.CreateMap<LeagueDto, League>();
                cfg.CreateMap<TeamForCreationDto, Team>();
                cfg.CreateMap<Team, TeamDto>();

            });

            app.UseMvc();
        }
    }
}
