using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;

namespace Descobrindo_o_mundo_API
{
    public partial class descobrindo_mundoContext : DbContext
    {
        public descobrindo_mundoContext()
        {
        }

        public descobrindo_mundoContext(DbContextOptions<descobrindo_mundoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblComponente> TblComponente { get; set; }
        public virtual DbSet<TblJogo> TblJogo { get; set; }
        public virtual DbSet<TblPaciente> TblPaciente { get; set; }
        public virtual DbSet<TblPalavra> TblPalavra { get; set; }
        public virtual DbSet<TblPartida> TblPartida { get; set; }
        public virtual DbSet<TblProfissional> TblProfissional { get; set; }
        public virtual DbSet<TblSilaba> TblSilaba { get; set; }
        public virtual DbSet<TblTipo> TblTipo { get; set; }
        public virtual DbSet<TblTipoComponente> TblTipoComponente { get; set; }
        public virtual DbSet<TblUsuario> TblUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=192.168.0.73\\SQLEXPRESS;Initial Catalog=descobrindo_mundo;Persist Security Info=True;User ID=lucas; Password=Lucas@1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblComponente>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_COMPONENTE");

                entity.HasIndex(e => e.LocalizacaoComponente)
                    .HasName("UQ__TBL_COMP__6283604F7652170B")
                    .IsUnique();

                entity.HasIndex(e => e.NmComponente)
                    .HasName("UQ__TBL_COMP__2C103DADE4D3158F")
                    .IsUnique();

                entity.Property(e => e.DscComponente)
                    .IsRequired()
                    .HasColumnName("dsc_componente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdComponente)
                    .HasColumnName("id_componente")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdPalavraComponente).HasColumnName("id_palavra_componente");

                entity.Property(e => e.LocalizacaoComponente)
                    .IsRequired()
                    .HasColumnName("localizacao_componente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NmComponente)
                    .IsRequired()
                    .HasColumnName("nm_componente")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TpComponente).HasColumnName("tp_componente");
            });

            modelBuilder.Entity<TblJogo>(entity =>
            {
                entity.HasKey(e => e.IdJogo)
                    .HasName("PK_JOGO");

                entity.ToTable("TBL_JOGO");

                entity.Property(e => e.IdJogo).HasColumnName("id_jogo");

                entity.Property(e => e.NmJogo)
                    .IsRequired()
                    .HasColumnName("nm_jogo")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPaciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK_PACIENTE");

                entity.ToTable("TBL_PACIENTE");

                entity.HasIndex(e => e.DscNicknamePaciente)
                    .HasName("UQ__TBL_PACI__130D1A6AF162B331")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuarioPaciente)
                    .HasName("UQ__TBL_PACI__993FE67D55E86254")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.Property(e => e.DscNicknamePaciente)
                    .IsRequired()
                    .HasColumnName("dsc_nickname_paciente")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuarioPaciente).HasColumnName("id_usuario_paciente");

                entity.HasOne(d => d.IdUsuarioPacienteNavigation)
                    .WithOne(p => p.TblPaciente)
                    .HasForeignKey<TblPaciente>(d => d.IdUsuarioPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_PACIENTE");
            });

            modelBuilder.Entity<TblPalavra>(entity =>
            {
                entity.HasKey(e => e.IdPalavra)
                    .HasName("PK_PALAVRA");

                entity.ToTable("TBL_PALAVRA");

                entity.HasIndex(e => e.NmPalavra)
                    .HasName("UQ__TBL_PALA__37E8C317B5381302")
                    .IsUnique();

                entity.Property(e => e.IdPalavra).HasColumnName("id_palavra");

                entity.Property(e => e.NmPalavra)
                    .IsRequired()
                    .HasColumnName("nm_palavra")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPartida>(entity =>
            {
                entity.HasKey(e => e.IdPartida)
                    .HasName("PK_PARTIDA");

                entity.ToTable("TBL_PARTIDA");

                entity.Property(e => e.IdPartida).HasColumnName("id_partida");

                entity.Property(e => e.DtPartida)
                    .HasColumnName("dt_partida")
                    .HasColumnType("date");

                entity.Property(e => e.DuracaoPartida).HasColumnName("duracao_partida");

                entity.Property(e => e.IdJogoPartida).HasColumnName("id_jogo_partida");

                entity.Property(e => e.IdPacientePartida).HasColumnName("id_paciente_partida");

                entity.Property(e => e.IdPalavraPartida).HasColumnName("id_palavra_partida");

                entity.Property(e => e.QtdAcertosPartida)
                    .HasColumnName("qtd_acertos_partida")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.QtdErrosPartida)
                    .HasColumnName("qtd_erros_partida")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.StatusPartida)
                    .IsRequired()
                    .HasColumnName("status_partida")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdJogoPartidaNavigation)
                    .WithMany(p => p.TblPartida)
                    .HasForeignKey(d => d.IdJogoPartida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOGO_PARTIDA");

                entity.HasOne(d => d.IdPacientePartidaNavigation)
                    .WithMany(p => p.TblPartida)
                    .HasForeignKey(d => d.IdPacientePartida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PACIENTE_PARTIDA");

                entity.HasOne(d => d.IdPalavraPartidaNavigation)
                    .WithMany(p => p.TblPartida)
                    .HasForeignKey(d => d.IdPalavraPartida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PALAVRA_PARTIDA");
            });

            modelBuilder.Entity<TblProfissional>(entity =>
            {
                entity.HasKey(e => e.IdProfissional)
                    .HasName("PK_PROFISSIONAL");

                entity.ToTable("TBL_PROFISSIONAL");

                entity.HasIndex(e => e.CrmProfissional)
                    .HasName("UQ__TBL_PROF__7CCDD0AE173367A0")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuarioProfissional)
                    .HasName("UQ__TBL_PROF__4665F2652DD89FF9")
                    .IsUnique();

                entity.Property(e => e.IdProfissional).HasColumnName("id_profissional");

                entity.Property(e => e.CrmProfissional)
                    .IsRequired()
                    .HasColumnName("crm_profissional")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuarioProfissional).HasColumnName("id_usuario_profissional");

                entity.HasOne(d => d.IdUsuarioProfissionalNavigation)
                    .WithOne(p => p.TblProfissional)
                    .HasForeignKey<TblProfissional>(d => d.IdUsuarioProfissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_PROFISSIONAL");
            });

            modelBuilder.Entity<TblSilaba>(entity =>
            {
                entity.HasKey(e => e.IdSilaba)
                    .HasName("PK_SILABA");

                entity.ToTable("TBL_SILABA");

                entity.HasIndex(e => e.IdPalavraSilaba)
                    .HasName("UQ__TBL_SILA__71DEC3FB59B8053D")
                    .IsUnique();

                entity.Property(e => e.IdSilaba).HasColumnName("id_silaba");

                entity.Property(e => e.IdPalavraSilaba).HasColumnName("id_palavra_silaba");

                entity.Property(e => e.SlbsCorretasSilaba)
                    .IsRequired()
                    .HasColumnName("slbs_corretas_silaba")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SlbsIncorretasSilaba)
                    .IsRequired()
                    .HasColumnName("slbs_incorretas_silaba")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPalavraSilabaNavigation)
                    .WithOne(p => p.TblSilaba)
                    .HasForeignKey<TblSilaba>(d => d.IdPalavraSilaba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PALAVRA_SILABA");
            });

            modelBuilder.Entity<TblTipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK_TIPO");

                entity.ToTable("TBL_TIPO");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.NmTipo)
                    .IsRequired()
                    .HasColumnName("nm_tipo")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoComponente>(entity =>
            {
                entity.HasKey(e => e.IdTipoComponente)
                    .HasName("PK_TIPO_COMPONENTE");

                entity.ToTable("TBL_TIPO_COMPONENTE");

                entity.Property(e => e.IdTipoComponente).HasColumnName("id_tipo_componente");

                entity.Property(e => e.NmTipoComponenete)
                    .IsRequired()
                    .HasColumnName("nm_tipo_componenete")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_USUARIO");

                entity.ToTable("TBL_USUARIO");

                entity.HasIndex(e => e.EmailUsuario)
                    .HasName("UQ__TBL_USUA__CD3151FF0A1C9742")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.DtNascUsuario)
                    .HasColumnName("dt_nasc_usuario")
                    .HasColumnType("date");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasColumnName("email_usuario")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.NmUsuario)
                    .IsRequired()
                    .HasColumnName("nm_usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SbrnmUsuario)
                    .IsRequired()
                    .HasColumnName("sbrnm_usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasColumnName("senha_usuario")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.TblUsuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPO_USUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
