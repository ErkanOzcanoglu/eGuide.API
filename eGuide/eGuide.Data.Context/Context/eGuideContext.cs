
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entites.Client;
using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Admin;
using eGuide.Data.Entities.Client;
using eGuide.Data.Entities.Map;
using eGuide.Data.Entities.Station;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace eGuide.Data.Context.Context {
    public class eGuideContext : DbContext {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="eGuideContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public eGuideContext(DbContextOptions<eGuideContext> options) : base(options) {
        }
       
        /// <summary>
        /// Initializes a new instance of the <see cref="eGuideContext"/> class.
        /// </summary>
        /// <remarks>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information and examples.
        /// </remarks>
        public eGuideContext() { }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run. However, it will still run when creating a compiled model.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
        /// examples.
        /// </para>
        /// </remarks>
        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //    base.OnModelCreating(modelBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)//PROTECTED 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Gets or sets the admin.
        /// </summary>
        /// <value>
        /// The admin.
        /// </value>
        public DbSet<AdminProfile> Admin { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public DbSet<Color> Color { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public DbSet<Comment> Comment { get; set; }

        /// <summary>
        /// Gets or sets the connector.
        /// </summary>
        /// <value>
        /// The connector.
        /// </value>
        public DbSet<Connector> Connector { get; set; }

        /// <summary>
        /// Gets or sets the facility.
        /// </summary>
        /// <value>
        /// The facility.
        /// </value>
        public DbSet<Facility> Facility { get; set; }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>
        /// The point.
        /// </value>
        public DbSet<Point> Point { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>
        /// The route.
        /// </value>
        public DbSet<Route> Route { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public DbSet<Services> Service { get; set; }

        /// <summary>
        /// Gets or sets the socket.
        /// </summary>
        /// <value>
        /// The socket.
        /// </value>
        public DbSet<ChargingUnit> CharginUnit { get; set; }

        /// <summary>
        /// Gets or sets the social media.
        /// </summary>
        /// <value>
        /// The social media.
        /// </value>
        public DbSet<SocialMedia> SocialMedia { get; set; }

        /// <summary>
        /// Gets or sets the station.
        /// </summary>
        /// <value>
        /// The station.
        /// </value>
        public DbSet<StationProfile> Station { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Gets or sets the vehicle.
        /// </summary>
        /// <value>
        /// The vehicle.
        /// </value>
        public DbSet<Vehicle> Vehicle { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public DbSet<Website> Website { get; set; }

        /// <summary>
        /// Gets or sets the user vehicle.
        /// </summary>
        /// <value>
        /// The user vehicle.
        /// </value>
        public DbSet<UserVehicle> UserVehicle { get; set; }

        /// <summary>
        /// Gets or sets the station model.
        /// </summary>
        /// <value>
        /// The station model.
        /// </value>
        public DbSet<StationModel> StationModels { get; set; }

        /// <summary>
        /// Gets or sets the station socket.
        /// </summary>
        /// <value>
        /// The station socket.
        /// </value>
        public DbSet<StationsChargingUnits> StationsChargingUnits { get; set; }

        /// <summary>
        /// Gets or sets the station information dto.
        /// </summary>
        /// <value>
        /// The station information dto.
        /// </value>
        public DbSet<StationInformationModel> StationInformationModel { get; set; }

        /// <summary>
        /// Gets or sets the user station.
        /// </summary>
        /// <value>
        /// The user station.
        /// </value>
        public DbSet<UserStation> UserStation { get; set; }
    }
}
