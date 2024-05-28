namespace TiendaMovilesProyectoFinal.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesorios",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 50),
                    Descripcion = c.String(nullable: false, maxLength: 300),
                    Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ImagenUrl = c.String(),
                    MarcaId = c.Int(nullable: false),
                    ModeloId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId)
                .ForeignKey("dbo.Modeloes", t => t.ModeloId)
                .Index(t => t.MarcaId)
                .Index(t => t.ModeloId);

            CreateTable(
                "dbo.Marcas",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Modeloes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Valoracions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Comentario = c.String(nullable: false, maxLength: 50),
                    Puntuacion = c.Int(nullable: false),
                    DispositivoId = c.Int(nullable: false),
                    Accesorio_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dispositivoes", t => t.DispositivoId)
                .ForeignKey("dbo.Accesorios", t => t.Accesorio_Id)
                .Index(t => t.DispositivoId)
                .Index(t => t.Accesorio_Id);

            CreateTable(
                "dbo.Dispositivoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 50),
                    Descripcion = c.String(maxLength: 300),
                    Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ImagenUrl = c.String(),
                    MarcaId = c.Int(nullable: false),
                    ModeloId = c.Int(nullable: false),
                    SistemaOperativoId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId)
                .ForeignKey("dbo.Modeloes", t => t.ModeloId)
                .ForeignKey("dbo.SistemaOperativoes", t => t.SistemaOperativoId)
                .Index(t => t.MarcaId)
                .Index(t => t.ModeloId)
                .Index(t => t.SistemaOperativoId);

            CreateTable(
                "dbo.SistemaOperativoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Valoracions", "Accesorio_Id", "dbo.Accesorios");
            DropForeignKey("dbo.Valoracions", "DispositivoId", "dbo.Dispositivoes");
            DropForeignKey("dbo.Dispositivoes", "SistemaOperativoId", "dbo.SistemaOperativoes");
            DropForeignKey("dbo.Dispositivoes", "ModeloId", "dbo.Modeloes");
            DropForeignKey("dbo.Dispositivoes", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Accesorios", "ModeloId", "dbo.Modeloes");
            DropForeignKey("dbo.Accesorios", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Dispositivoes", new[] { "SistemaOperativoId" });
            DropIndex("dbo.Dispositivoes", new[] { "ModeloId" });
            DropIndex("dbo.Dispositivoes", new[] { "MarcaId" });
            DropIndex("dbo.Valoracions", new[] { "Accesorio_Id" });
            DropIndex("dbo.Valoracions", new[] { "DispositivoId" });
            DropIndex("dbo.Accesorios", new[] { "ModeloId" });
            DropIndex("dbo.Accesorios", new[] { "MarcaId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SistemaOperativoes");
            DropTable("dbo.Dispositivoes");
            DropTable("dbo.Valoracions");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Accesorios");
        }
    }
}
