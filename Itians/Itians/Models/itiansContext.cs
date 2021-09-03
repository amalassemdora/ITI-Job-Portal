using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Itians.Models
{
    public partial class itiansContext : DbContext
    {
        public itiansContext()
        {
        }

        public itiansContext(DbContextOptions<itiansContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentLike> CommentLikes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyLocation> CompanyLocations { get; set; }
        public virtual DbSet<CompanyType> CompanyTypes { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupAdmin> GroupAdmins { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<JobPost> JobPosts { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<JobsApplied> JobsApplieds { get; set; }
        public virtual DbSet<JobsSaved> JobsSaveds { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostLike> PostLikes { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<ReplyLike> ReplyLikes { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserEducation> UserEducations { get; set; }
        public virtual DbSet<UserExperience> UserExperiences { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserRelation> UserRelations { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=itians;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.Body)
                    .HasMaxLength(300)
                    .HasColumnName("body");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comments_posts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comments_Users");
            });

            modelBuilder.Entity<CommentLike>(entity =>
            {
                entity.ToTable("comment_likes");

                entity.Property(e => e.CommentLikeId).HasColumnName("comment_like_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentLikes)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_comment_likes_Comments");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentLikes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_comment_likes_Users");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Adress)
                    .HasMaxLength(800)
                    .HasColumnName("adress");

                entity.Property(e => e.CommentFromAdmin)
                    .HasMaxLength(800)
                    .HasColumnName("comment_from_admin")
                    .HasDefaultValueSql("(N'Admins will approve you soon...')");

                entity.Property(e => e.CompanyTypeId).HasColumnName("company_type_id");

                entity.Property(e => e.CompanyUsername)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("company_username");

                entity.Property(e => e.Cover).HasColumnName("cover");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.EstablishDate)
                    .HasColumnType("date")
                    .HasColumnName("establish_date");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.License)
                    .IsRequired()
                    .HasColumnName("license");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("website_url");

                entity.HasOne(d => d.CompanyType)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CompanyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_company_type");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Company_User_Roles");
            });

            modelBuilder.Entity<CompanyLocation>(entity =>
            {
                entity.ToTable("Company_location");

                entity.Property(e => e.CompanyLocationId).HasColumnName("company_location_id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("street");

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .HasColumnName("zip");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyLocations)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Company_location_Company");
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.ToTable("company_type");

                entity.Property(e => e.CompanyTypeId).HasColumnName("company_type_id");

                entity.Property(e => e.CompanyTyppe)
                    .HasMaxLength(50)
                    .HasColumnName("company_typpe");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasKey(e => new { e.UserId1, e.UserId2 });

                entity.Property(e => e.UserId1).HasColumnName("user_id1");

                entity.Property(e => e.UserId2).HasColumnName("user_id2");

                entity.Property(e => e.RelationId)
                    .HasColumnName("relation_id")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.RelationId)
                    .HasConstraintName("FK_Friends_User_relations");

                entity.HasOne(d => d.UserId1Navigation)
                    .WithMany(p => p.FriendUserId1Navigations)
                    .HasForeignKey(d => d.UserId1)
                    .HasConstraintName("FK_Friends_Users");

                entity.HasOne(d => d.UserId2Navigation)
                    .WithMany(p => p.FriendUserId2Navigations)
                    .HasForeignKey(d => d.UserId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friends_Users1");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupCover).HasColumnName("group_cover");

                entity.Property(e => e.GroupDesc)
                    .HasMaxLength(400)
                    .HasColumnName("group_desc");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("group_name");
            });

            modelBuilder.Entity<GroupAdmin>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId });

                entity.ToTable("Group_admins");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupAdmins)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Group_admins_Groups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupAdmins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Group_admins_Users");
            });

            modelBuilder.Entity<GroupUser>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId });

                entity.ToTable("Group_user");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Group_user_Groups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Group_user_Users");
            });

            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.HasKey(e => e.IdJob);

                entity.ToTable("job_post");

                entity.Property(e => e.IdJob).HasColumnName("id_job");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Counrty)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("counrty");

                entity.Property(e => e.CreatedData)
                    .HasColumnType("date")
                    .HasColumnName("created_data")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.JobDesc)
                    .IsRequired()
                    .HasColumnName("job_desc");

                entity.Property(e => e.JobTypeId).HasColumnName("job_type_id");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("street");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .HasColumnName("title");

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .HasColumnName("zip");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.JobPosts)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_job_post_Company");

                entity.HasOne(d => d.JobType)
                    .WithMany(p => p.JobPosts)
                    .HasForeignKey(d => d.JobTypeId)
                    .HasConstraintName("FK_job_post_job_type1");
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.ToTable("job_type");

                entity.Property(e => e.JobTypeId).HasColumnName("job_type_id");

                entity.Property(e => e.JobType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("job_type");
            });

            modelBuilder.Entity<JobsApplied>(entity =>
            {
                entity.HasKey(e => new { e.IdJob, e.UserId });

                entity.ToTable("Jobs_Applied");

                entity.Property(e => e.IdJob).HasColumnName("id_job");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AppliedDate)
                    .HasColumnType("date")
                    .HasColumnName("applied_date");

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.JobsApplieds)
                    .HasForeignKey(d => d.IdJob)
                    .HasConstraintName("FK_Jobs_Applied_job_post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobsApplieds)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Jobs_Applied_Users");
            });

            modelBuilder.Entity<JobsSaved>(entity =>
            {
                entity.HasKey(e => new { e.IdJob, e.UserId });

                entity.ToTable("jobs_saved");

                entity.Property(e => e.IdJob).HasColumnName("id_job");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.SavedDate)
                    .HasColumnType("date")
                    .HasColumnName("saved_date");

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.JobsSaveds)
                    .HasForeignKey(d => d.IdJob)
                    .HasConstraintName("FK_jobs_saved_job_post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobsSaveds)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_jobs_saved_Users");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("body");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_posts_Users");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_posts_Groups");
            });

            modelBuilder.Entity<PostLike>(entity =>
            {
                entity.ToTable("post_likes");

                entity.Property(e => e.PostLikeId).HasColumnName("post_like_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostLikes)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_post_likes_posts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_post_likes_Users");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("replies");

                entity.Property(e => e.ReplyId).HasColumnName("reply_id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("body");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_replies_Comments");
            });

            modelBuilder.Entity<ReplyLike>(entity =>
            {
                entity.ToTable("reply_likes");

                entity.Property(e => e.ReplyLikeId).HasColumnName("reply_like_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReplyId).HasColumnName("reply_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Reply)
                    .WithMany(p => p.ReplyLikes)
                    .HasForeignKey(d => d.ReplyId)
                    .HasConstraintName("FK_reply_likes_replies");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReplyLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reply_likes_Users");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("skill_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CommentFromAdmin)
                    .HasMaxLength(800)
                    .HasColumnName("comment_from_admin")
                    .HasDefaultValueSql("(N'Admins will approve you soon...')");

                entity.Property(e => e.Cover).HasColumnName("cover");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.License)
                    .IsRequired()
                    .HasColumnName("license");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .HasColumnName("mobile");

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("national_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.RegisterationDate)
                    .HasColumnType("date")
                    .HasColumnName("registeration_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_User_Roles");
            });

            modelBuilder.Entity<UserEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId)
                    .HasName("PK_User_Education_1");

                entity.ToTable("User_Education");

                entity.Property(e => e.EducationId).HasColumnName("education_id");

                entity.Property(e => e.CertificateDegree)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("certificate_degree");

                entity.Property(e => e.EndingDate)
                    .HasColumnType("date")
                    .HasColumnName("ending_date");

                entity.Property(e => e.Gpa).HasColumnName("GPA");

                entity.Property(e => e.Major)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("major");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("date")
                    .HasColumnName("starting_date");

                entity.Property(e => e.Universty)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("universty");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEducations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Education_User_profile");
            });

            modelBuilder.Entity<UserExperience>(entity =>
            {
                entity.HasKey(e => e.ExperienceId)
                    .HasName("PK_User_Experience_1");

                entity.ToTable("User_Experience");

                entity.Property(e => e.ExperienceId).HasColumnName("experience_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("company_name");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .HasColumnName("description");

                entity.Property(e => e.EndingDate)
                    .HasColumnType("date")
                    .HasColumnName("ending_date");

                entity.Property(e => e.LocationCity)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("location_city");

                entity.Property(e => e.LocationCountry)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("location_country");

                entity.Property(e => e.LocationState)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("location_state");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("position");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("date")
                    .HasColumnName("starting_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserExperiences)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Experience_User_profile");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("User_profile");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.AboutMe)
                    .HasMaxLength(450)
                    .HasColumnName("about_me");

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .HasColumnName("currency");

                entity.Property(e => e.CurrrentSalary).HasColumnName("currrent_salary");

                entity.Property(e => e.Cv).HasColumnName("cv");

                entity.Property(e => e.FormalEmail)
                    .HasMaxLength(250)
                    .HasColumnName("formal_email");

                entity.Property(e => e.Github)
                    .HasMaxLength(250)
                    .HasColumnName("github");

                entity.Property(e => e.IsYearlyMonthly)
                    .IsRequired()
                    .HasColumnName("isYearlyMonthly")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Linkedin)
                    .HasMaxLength(250)
                    .HasColumnName("linkedin");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserProfile)
                    .HasForeignKey<UserProfile>(d => d.UserId)
                    .HasConstraintName("FK_User_profile_Users");
            });

            modelBuilder.Entity<UserRelation>(entity =>
            {
                entity.HasKey(e => e.RelationId);

                entity.ToTable("User_relations");

                entity.Property(e => e.RelationId).HasColumnName("relation_id");

                entity.Property(e => e.RelationName)
                    .HasMaxLength(50)
                    .HasColumnName("relation_name");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("User_Roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SkillId });

                entity.ToTable("User_skills");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillLevel).HasColumnName("skill_level");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_User_skills_Skills");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_skills_User_profile");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
