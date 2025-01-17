﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Travel.WebApi.Models;

public partial class FinalContext : DbContext
{
    public FinalContext()
    {
    }

    public FinalContext(DbContextOptions<FinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accommodation> Accommodations { get; set; }

    public virtual DbSet<ArticleCustomizationList> ArticleCustomizationLists { get; set; }

    public virtual DbSet<ArticleList> ArticleLists { get; set; }

    public virtual DbSet<ArticleOverview> ArticleOverviews { get; set; }

    public virtual DbSet<ArticlePicture> ArticlePictures { get; set; }

    public virtual DbSet<ArticleRepository> ArticleRepositories { get; set; }

    public virtual DbSet<BasicCommodityInformation> BasicCommodityInformations { get; set; }

    public virtual DbSet<BasicMemberInformation> BasicMemberInformations { get; set; }

    public virtual DbSet<BodyshapeTable> BodyshapeTables { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommodityInteractive> CommodityInteractives { get; set; }

    public virtual DbSet<CommodityInterest> CommodityInterests { get; set; }

    public virtual DbSet<CommodityLanguage> CommodityLanguages { get; set; }

    public virtual DbSet<CommodityPicture> CommodityPictures { get; set; }

    public virtual DbSet<CouponDiscountTable> CouponDiscountTables { get; set; }

    public virtual DbSet<CouponTable> CouponTables { get; set; }

    public virtual DbSet<Coupontable1> Coupontables1 { get; set; }

    public virtual DbSet<GoldExchangeTable> GoldExchangeTables { get; set; }

    public virtual DbSet<InteractiveTable> InteractiveTables { get; set; }

    public virtual DbSet<InterestTable> InterestTables { get; set; }

    public virtual DbSet<LanguageTable> LanguageTables { get; set; }

    public virtual DbSet<LevelTable> LevelTables { get; set; }

    public virtual DbSet<MallProductPurchaseRecord> MallProductPurchaseRecords { get; set; }

    public virtual DbSet<MallProductSpace> MallProductSpaces { get; set; }

    public virtual DbSet<MallProductTable> MallProductTables { get; set; }

    public virtual DbSet<MembersLike> MembersLikes { get; set; }

    public virtual DbSet<OfflineAreaTable> OfflineAreaTables { get; set; }

    public virtual DbSet<OfflineTypeTable> OfflineTypeTables { get; set; }

    public virtual DbSet<OnlineTypeTable> OnlineTypeTables { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<ProductDatetime> ProductDatetimes { get; set; }

    public virtual DbSet<ProductOfflineTopic> ProductOfflineTopics { get; set; }

    public virtual DbSet<ProductOnlineTopic> ProductOnlineTopics { get; set; }

    public virtual DbSet<ProductTravel> ProductTravels { get; set; }

    public virtual DbSet<ProfessionTable> ProfessionTables { get; set; }

    public virtual DbSet<Shoprecord> Shoprecords { get; set; }

    public virtual DbSet<ShoprecordDetail> ShoprecordDetails { get; set; }

    public virtual DbSet<Storedrecord> Storedrecords { get; set; }

    public virtual DbSet<Tracklist> Tracklists { get; set; }

    public virtual DbSet<TravelDetail> TravelDetails { get; set; }

    public virtual DbSet<TravelTransportationTable> TravelTransportationTables { get; set; }

    public virtual DbSet<TravelareaTable> TravelareaTables { get; set; }

    public virtual DbSet<TravelpicturesTable> TravelpicturesTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=final;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accommodation>(entity =>
        {
            entity.ToTable("accommodation");

            entity.Property(e => e.AccommodationId).HasColumnName("accommodation_id");
            entity.Property(e => e.AccommodationName).HasColumnName("accommodation_name");
            entity.Property(e => e.CheckinDate).HasColumnName("checkin_date");
            entity.Property(e => e.CheckoutDate).HasColumnName("checkout_date");
            entity.Property(e => e.Location).HasColumnName("location");
        });

        modelBuilder.Entity<ArticleCustomizationList>(entity =>
        {
            entity.HasKey(e => e.ArticleListId);

            entity.ToTable("article_customization_list");

            entity.Property(e => e.ArticleListId).HasColumnName("article_list_id");
            entity.Property(e => e.ArticleListName)
                .HasMaxLength(50)
                .HasColumnName("article_list_name");
        });

        modelBuilder.Entity<ArticleList>(entity =>
        {
            entity.ToTable("article_list");

            entity.Property(e => e.ArticleListId).HasColumnName("article_list_id");
            entity.Property(e => e.ArticleListName).HasColumnName("article_list_name");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");

            entity.HasOne(d => d.Memberunique).WithMany(p => p.ArticleLists)
                .HasForeignKey(d => d.MemberuniqueId)
                .HasConstraintName("FK_article_list_basic_member_information");
        });

        modelBuilder.Entity<ArticleOverview>(entity =>
        {
            entity.HasKey(e => e.ArticleId);

            entity.ToTable("article_overview");

            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.ArticleContent).HasColumnName("article_content");
            entity.Property(e => e.ArticleCoverImage).HasColumnName("article_cover_image");
            entity.Property(e => e.ArticleName).HasColumnName("article_name");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");
            entity.Property(e => e.Tag).HasColumnName("tag");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");

            entity.HasOne(d => d.Memberunique).WithMany(p => p.ArticleOverviews)
                .HasForeignKey(d => d.MemberuniqueId)
                .HasConstraintName("FK_article_overview_basic_member_information");
        });

        modelBuilder.Entity<ArticlePicture>(entity =>
        {
            entity.HasKey(e => e.ArticlePicturesId);

            entity.ToTable("article_picture");

            entity.Property(e => e.ArticlePicturesId).HasColumnName("article_pictures_id");
            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.ArticlePictures).HasColumnName("article_pictures");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticlePictures)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_article_picture_article_overview");
        });

        modelBuilder.Entity<ArticleRepository>(entity =>
        {
            entity.ToTable("article_repository");

            entity.Property(e => e.ArticleRepositoryId).HasColumnName("article_repository_id");
            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.ArticleListId).HasColumnName("article_list_id");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticleRepositories)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_article_repository_article_overview");

            entity.HasOne(d => d.ArticleList).WithMany(p => p.ArticleRepositories)
                .HasForeignKey(d => d.ArticleListId)
                .HasConstraintName("FK_article_repository_article_list");
        });

        modelBuilder.Entity<BasicCommodityInformation>(entity =>
        {
            entity.HasKey(e => e.CommodityId).HasName("PK_basiccommodityinformation");

            entity.ToTable("basic_commodity_information");

            entity.Property(e => e.CommodityId).HasColumnName("commodity_id");
            entity.Property(e => e.BodyshapeId)
                .HasMaxLength(50)
                .HasColumnName("bodyshape_id");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.LoverNickname)
                .HasMaxLength(50)
                .HasColumnName("lover_nickname");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");
            entity.Property(e => e.ProfessionId)
                .HasMaxLength(50)
                .HasColumnName("profession_id");

            entity.HasOne(d => d.Bodyshape).WithMany(p => p.BasicCommodityInformations)
                .HasForeignKey(d => d.BodyshapeId)
                .HasConstraintName("FK_basic_commodity_information_bodyshape_table");

            entity.HasOne(d => d.Memberunique).WithMany(p => p.BasicCommodityInformations)
                .HasForeignKey(d => d.MemberuniqueId)
                .HasConstraintName("FK_basic_commodity_information_basic_member_information");

            entity.HasOne(d => d.Profession).WithMany(p => p.BasicCommodityInformations)
                .HasForeignKey(d => d.ProfessionId)
                .HasConstraintName("FK_basic_commodity_information_profession_table");
        });

        modelBuilder.Entity<BasicMemberInformation>(entity =>
        {
            entity.HasKey(e => e.MemberuniqueId);

            entity.ToTable("basic_member_information");

            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");
            entity.Property(e => e.Activate).HasColumnName("activate");
            entity.Property(e => e.BeCommodity).HasColumnName("be_commodity");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Followers).HasColumnName("followers");
            entity.Property(e => e.HouseCreatetime)
                .HasColumnType("datetime")
                .HasColumnName("house_createtime");
            entity.Property(e => e.HouseName)
                .HasMaxLength(50)
                .HasColumnName("house_name");
            entity.Property(e => e.HouseRenewtime)
                .HasColumnType("datetime")
                .HasColumnName("house_renewtime");
            entity.Property(e => e.Introduction)
                .HasMaxLength(50)
                .HasColumnName("introduction");
            entity.Property(e => e.LevelId).HasColumnName("level_id");
            entity.Property(e => e.MemberName)
                .HasMaxLength(50)
                .HasColumnName("member_name");
            entity.Property(e => e.MemberPicture).HasColumnName("member_picture");
            entity.Property(e => e.MemberValue)
                .HasColumnType("money")
                .HasColumnName("member_value");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Tracks).HasColumnName("tracks");

            entity.HasOne(d => d.Level).WithMany(p => p.BasicMemberInformations)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK_basic_member_information_level_table");
        });

        modelBuilder.Entity<BodyshapeTable>(entity =>
        {
            entity.HasKey(e => e.BodyshapeId).HasName("PK_身形");

            entity.ToTable("bodyshape_table");

            entity.Property(e => e.BodyshapeId)
                .HasMaxLength(50)
                .HasColumnName("bodyshape_id");
            entity.Property(e => e.BodyshapeName)
                .HasMaxLength(50)
                .HasColumnName("bodyshape_name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comment");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.CommentContent).HasColumnName("comment_content");
            entity.Property(e => e.CommentDateTime)
                .HasColumnType("datetime")
                .HasColumnName("comment_date_time");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");

            entity.HasOne(d => d.Article).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_comment_article_overview");

            entity.HasOne(d => d.Memberunique).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MemberuniqueId)
                .HasConstraintName("FK_comment_basic_member_information");
        });

        modelBuilder.Entity<CommodityInteractive>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commodity_interactive");

            entity.Property(e => e.CommodityId).HasColumnName("commodity_id");
            entity.Property(e => e.InteractiveId)
                .HasMaxLength(50)
                .HasColumnName("interactive_id");

            entity.HasOne(d => d.Commodity).WithMany()
                .HasForeignKey(d => d.CommodityId)
                .HasConstraintName("FK_commodity_interactive_basic_commodity_information");

            entity.HasOne(d => d.Interactive).WithMany()
                .HasForeignKey(d => d.InteractiveId)
                .HasConstraintName("FK_commodity_interactive_interactive_table");
        });

        modelBuilder.Entity<CommodityInterest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commodity_interest");

            entity.Property(e => e.CommodityId).HasColumnName("commodity_id");
            entity.Property(e => e.InterestId)
                .HasMaxLength(50)
                .HasColumnName("interest_id");

            entity.HasOne(d => d.Commodity).WithMany()
                .HasForeignKey(d => d.CommodityId)
                .HasConstraintName("FK_commodity_interest_basic_commodity_information");

            entity.HasOne(d => d.Interest).WithMany()
                .HasForeignKey(d => d.InterestId)
                .HasConstraintName("FK_commodity_interest_interest_table ");
        });

        modelBuilder.Entity<CommodityLanguage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commodity_language");

            entity.Property(e => e.CommodityId).HasColumnName("commodity_id");
            entity.Property(e => e.LanguageId)
                .HasMaxLength(50)
                .HasColumnName("language_id");

            entity.HasOne(d => d.Commodity).WithMany()
                .HasForeignKey(d => d.CommodityId)
                .HasConstraintName("FK_commodity_language_basic_commodity_information");

            entity.HasOne(d => d.Language).WithMany()
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_commodity_language_language_table");
        });

        modelBuilder.Entity<CommodityPicture>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commodity_picture");

            entity.Property(e => e.CommodityId).HasColumnName("commodity_id");
            entity.Property(e => e.CommodityPictures).HasColumnName("commodity_pictures");

            entity.HasOne(d => d.Commodity).WithMany()
                .HasForeignKey(d => d.CommodityId)
                .HasConstraintName("FK_commodity_picture_basic_commodity_information");
        });

        modelBuilder.Entity<CouponDiscountTable>(entity =>
        {
            entity.HasKey(e => e.CoupondiscountId).HasName("PK_優惠券折扣表");

            entity.ToTable("coupon_discount_table");

            entity.Property(e => e.CoupondiscountId)
                .HasMaxLength(50)
                .HasColumnName("coupondiscount_id");
            entity.Property(e => e.Discountamount)
                .HasColumnType("money")
                .HasColumnName("discountamount");
            entity.Property(e => e.Expirationdate)
                .HasColumnType("datetime")
                .HasColumnName("expirationdate");
        });

        modelBuilder.Entity<CouponTable>(entity =>
        {
            entity.HasKey(e => e.CouponId).HasName("PK_優惠券");

            entity.ToTable("coupon_table");

            entity.Property(e => e.CouponId)
                .ValueGeneratedNever()
                .HasColumnName("coupon_id");
            entity.Property(e => e.Couponame)
                .HasMaxLength(50)
                .HasColumnName("couponame");
            entity.Property(e => e.CoupondiscountId)
                .HasMaxLength(50)
                .HasColumnName("coupondiscount_id");
        });

        modelBuilder.Entity<Coupontable1>(entity =>
        {
            entity.HasKey(e => e.CouponId);

            entity.ToTable("coupontable");

            entity.Property(e => e.CouponId)
                .ValueGeneratedNever()
                .HasColumnName("coupon_id");
            entity.Property(e => e.Couponame)
                .HasMaxLength(50)
                .HasColumnName("couponame");
            entity.Property(e => e.CoupondiscountId)
                .HasMaxLength(50)
                .HasColumnName("coupondiscount_id");

            entity.HasOne(d => d.Coupondiscount).WithMany(p => p.Coupontable1s)
                .HasForeignKey(d => d.CoupondiscountId)
                .HasConstraintName("FK_coupontable_coupon_discount_table");
        });

        modelBuilder.Entity<GoldExchangeTable>(entity =>
        {
            entity.HasKey(e => e.GoldDenominationId).HasName("PK_goldexchangetable");

            entity.ToTable("gold_exchange_table");

            entity.Property(e => e.GoldDenominationId).HasColumnName("gold_denomination_id");
            entity.Property(e => e.GoldAmount)
                .HasColumnType("money")
                .HasColumnName("gold_amount");
            entity.Property(e => e.GoldDenominatioName)
                .HasMaxLength(50)
                .HasColumnName("gold_denominatio_name");
            entity.Property(e => e.StoredAmount)
                .HasColumnType("money")
                .HasColumnName("stored_amount");
        });

        modelBuilder.Entity<InteractiveTable>(entity =>
        {
            entity.HasKey(e => e.InteractiveId).HasName("PK_可接受互動項目");

            entity.ToTable("interactive_table");

            entity.Property(e => e.InteractiveId)
                .HasMaxLength(50)
                .HasColumnName("interactive_id");
            entity.Property(e => e.InteractiveName)
                .HasMaxLength(50)
                .HasColumnName("interactive_name");
        });

        modelBuilder.Entity<InterestTable>(entity =>
        {
            entity.HasKey(e => e.InterestId).HasName("PK_興趣");

            entity.ToTable("interest_table ");

            entity.Property(e => e.InterestId)
                .HasMaxLength(50)
                .HasColumnName("interest_id");
            entity.Property(e => e.InterestName)
                .HasMaxLength(50)
                .HasColumnName("interest_name");
        });

        modelBuilder.Entity<LanguageTable>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK_商品語言總覽");

            entity.ToTable("language_table");

            entity.Property(e => e.LanguageId)
                .HasMaxLength(50)
                .HasColumnName("language_id");
            entity.Property(e => e.LanguageName)
                .HasMaxLength(50)
                .HasColumnName("language_name");
        });

        modelBuilder.Entity<LevelTable>(entity =>
        {
            entity.HasKey(e => e.LevelId);

            entity.ToTable("level_table");

            entity.Property(e => e.LevelId).HasColumnName("level_id");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.LevelName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("level_name");
        });

        modelBuilder.Entity<MallProductPurchaseRecord>(entity =>
        {
            entity.HasKey(e => e.MprecordId);

            entity.ToTable("mall_product_purchase_record");

            entity.Property(e => e.MprecordId).HasColumnName("mprecord_id");
            entity.Property(e => e.ExchangeStatus).HasColumnName("exchange_status");
            entity.Property(e => e.ExchangeTime)
                .HasColumnType("datetime")
                .HasColumnName("exchange_time");
            entity.Property(e => e.MallProductTableId).HasColumnName("mall_product_table_id");
            entity.Property(e => e.MemberName)
                .HasMaxLength(50)
                .HasColumnName("member_name");

            entity.HasOne(d => d.MallProductTable).WithMany(p => p.MallProductPurchaseRecords)
                .HasForeignKey(d => d.MallProductTableId)
                .HasConstraintName("FK_mall_product_purchase_record_mall_product_table");
        });

        modelBuilder.Entity<MallProductSpace>(entity =>
        {
            entity.HasKey(e => e.PspaceId).HasName("PK_mallproductspace_1");

            entity.ToTable("mall_product_space");

            entity.Property(e => e.PspaceId).HasColumnName("pspace_id");
            entity.Property(e => e.MallProductAmount).HasColumnName("mall_product_amount");
            entity.Property(e => e.MallProductTableId).HasColumnName("mall_product_table_id");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");

            entity.HasOne(d => d.MallProductTable).WithMany(p => p.MallProductSpaces)
                .HasForeignKey(d => d.MallProductTableId)
                .HasConstraintName("FK_mall_product_space_mall_product_table");

            entity.HasOne(d => d.Memberunique).WithMany(p => p.MallProductSpaces)
                .HasForeignKey(d => d.MemberuniqueId)
                .HasConstraintName("FK_mall_product_space_basic_member_information");
        });

        modelBuilder.Entity<MallProductTable>(entity =>
        {
            entity.HasKey(e => e.MallProductTableId).HasName("PK_mallproductable");

            entity.ToTable("mall_product_table");

            entity.Property(e => e.MallProductTableId).HasColumnName("mall_product_table_id");
            entity.Property(e => e.GoldAmount).HasColumnName("gold_amount");
            entity.Property(e => e.MallProductId)
                .HasMaxLength(50)
                .HasColumnName("mall_product_id");
            entity.Property(e => e.MallProductName)
                .HasMaxLength(50)
                .HasColumnName("mall_product_name");
            entity.Property(e => e.Pimage).HasColumnName("pimage");
        });

        modelBuilder.Entity<MembersLike>(entity =>
        {
            entity.HasKey(e => e.LikesId);

            entity.ToTable("members_like");

            entity.Property(e => e.LikesId).HasColumnName("likes_id");
            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");

            entity.HasOne(d => d.Article).WithMany(p => p.MembersLikes)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_members_like_article_overview");

            entity.HasOne(d => d.Memberunique).WithMany(p => p.MembersLikes)
                .HasForeignKey(d => d.MemberuniqueId)
                .HasConstraintName("FK_members_like_basic_member_information");
        });

        modelBuilder.Entity<OfflineAreaTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("offline_area_table");

            entity.Property(e => e.AreaId)
                .HasMaxLength(50)
                .HasColumnName("area_id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(50)
                .HasColumnName("area_name");
        });

        modelBuilder.Entity<OfflineTypeTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("offline_type_table");

            entity.Property(e => e.OfflineTypeId)
                .HasMaxLength(50)
                .HasColumnName("offline_type_id");
            entity.Property(e => e.OfflineTypeName)
                .HasMaxLength(50)
                .HasColumnName("offline_type_name");
        });

        modelBuilder.Entity<OnlineTypeTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("online_type_table");

            entity.Property(e => e.OnlineTypeId)
                .HasMaxLength(50)
                .HasColumnName("online_type_id");
            entity.Property(e => e.OnlineTypeName)
                .HasMaxLength(50)
                .HasColumnName("online_type_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("order");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CommidityId).HasColumnName("commidity_id");
            entity.Property(e => e.CouponId).HasColumnName("coupon_id");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");
            entity.Property(e => e.Paymentstatus).HasColumnName("paymentstatus");
            entity.Property(e => e.PriceFixed)
                .HasColumnType("money")
                .HasColumnName("price_fixed");
            entity.Property(e => e.PriceUnfixed)
                .HasColumnType("money")
                .HasColumnName("price_unfixed");

            entity.HasOne(d => d.Commidity).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CommidityId)
                .HasConstraintName("FK_order_basic_commodity_information");
        });

        modelBuilder.Entity<ProductDatetime>(entity =>
        {
            entity.HasKey(e => e.NotypedatingId).HasName("PK_productdatetime");

            entity.ToTable("product_datetime");

            entity.Property(e => e.NotypedatingId).HasColumnName("notypedating_id");
            entity.Property(e => e.CommodityId).HasColumnName("commodity_id");
            entity.Property(e => e.DatingId)
                .HasMaxLength(50)
                .HasColumnName("dating_id");
            entity.Property(e => e.Datingdate).HasColumnName("datingdate");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProductShow).HasColumnName("product_show");
            entity.Property(e => e.Startime).HasColumnName("startime");

            entity.HasOne(d => d.Commodity).WithMany(p => p.ProductDatetimes)
                .HasForeignKey(d => d.CommodityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_datetime_basic_commodity_information");
        });

        modelBuilder.Entity<ProductOfflineTopic>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product_offline_topics");

            entity.Property(e => e.AreaId)
                .HasMaxLength(50)
                .HasColumnName("area_id");
            entity.Property(e => e.CommidityId).HasColumnName("commidity_id");
            entity.Property(e => e.DatingDate).HasColumnName("dating_date");
            entity.Property(e => e.DatingId)
                .HasMaxLength(50)
                .HasColumnName("dating_id");
            entity.Property(e => e.DowntopicId).HasColumnName("downtopic_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.OfflineTopicsName)
                .HasMaxLength(50)
                .HasColumnName("offline_topics_name");
            entity.Property(e => e.OfflineTypeId)
                .HasMaxLength(50)
                .HasColumnName("offline_type_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProductShow).HasColumnName("product_show");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
        });

        modelBuilder.Entity<ProductOnlineTopic>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product_online_topics");

            entity.Property(e => e.CommidityId).HasColumnName("commidity_id");
            entity.Property(e => e.DatingDate).HasColumnName("dating_date");
            entity.Property(e => e.DatingId)
                .HasMaxLength(50)
                .HasColumnName("dating_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.OnlineTopicsName)
                .HasMaxLength(50)
                .HasColumnName("online_topics_name");
            entity.Property(e => e.OnlineTypeId)
                .HasMaxLength(50)
                .HasColumnName("online_type_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProductShow).HasColumnName("product_show");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.UptopicId).HasColumnName("uptopic_id");
        });

        modelBuilder.Entity<ProductTravel>(entity =>
        {
            entity.HasKey(e => e.TravelId);

            entity.ToTable("product_travel");

            entity.Property(e => e.TravelId).HasColumnName("travel_id");
            entity.Property(e => e.AllDays).HasColumnName("All_days");
            entity.Property(e => e.Pictures)
                .HasMaxLength(50)
                .HasColumnName("pictures");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProductShow).HasColumnName("product_show");
            entity.Property(e => e.Tag)
                .HasMaxLength(50)
                .HasColumnName("tag");
            entity.Property(e => e.TravelDatetime)
                .HasColumnType("datetime")
                .HasColumnName("travel_datetime");
            entity.Property(e => e.TravelIntroduction).HasColumnName("travel_introduction");
            entity.Property(e => e.TravelMeetingpoint)
                .HasMaxLength(50)
                .HasColumnName("travel_meetingpoint");
            entity.Property(e => e.TravelName)
                .HasMaxLength(50)
                .HasColumnName("travel_name");
            entity.Property(e => e.TravelareaId).HasColumnName("travelarea_id");

            entity.HasOne(d => d.Travelarea).WithMany(p => p.ProductTravels)
                .HasForeignKey(d => d.TravelareaId)
                .HasConstraintName("FK_product_travel_travelarea_table");
        });

        modelBuilder.Entity<ProfessionTable>(entity =>
        {
            entity.HasKey(e => e.ProfessionId).HasName("PK_職業");

            entity.ToTable("profession_table");

            entity.Property(e => e.ProfessionId)
                .HasMaxLength(50)
                .HasColumnName("profession_id");
            entity.Property(e => e.ProfessionName)
                .HasMaxLength(50)
                .HasColumnName("profession_name");
        });

        modelBuilder.Entity<Shoprecord>(entity =>
        {
            entity.ToTable("shoprecord");

            entity.Property(e => e.ShopRecordid).HasColumnName("shop_recordid");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.ExchangeStatus).HasColumnName("exchange_status");
            entity.Property(e => e.MemberName)
                .HasMaxLength(50)
                .HasColumnName("member_name");
            entity.Property(e => e.MemberPhone)
                .HasMaxLength(20)
                .HasColumnName("member_phone");
            entity.Property(e => e.PurchaseTime)
                .HasColumnType("datetime")
                .HasColumnName("purchase_time");
            entity.Property(e => e.Shoporderid)
                .HasMaxLength(50)
                .HasColumnName("shoporderid");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
        });

        modelBuilder.Entity<ShoprecordDetail>(entity =>
        {
            entity.ToTable("shoprecord_detail");

            entity.Property(e => e.ShoprecordDetailid).HasColumnName("shoprecord_detailid");
            entity.Property(e => e.MallProductName).HasColumnName("mall_product_name");
            entity.Property(e => e.MallProductQuantity).HasColumnName("mall_product_quantity");
            entity.Property(e => e.MallProductTableId).HasColumnName("mall_product_table_id");
            entity.Property(e => e.ShopRecordid).HasColumnName("shop_recordid");
            entity.Property(e => e.Shoporderid)
                .HasMaxLength(50)
                .HasColumnName("shoporderid");

            entity.HasOne(d => d.MallProductTable).WithMany(p => p.ShoprecordDetails)
                .HasForeignKey(d => d.MallProductTableId)
                .HasConstraintName("FK_shoprecord_detail_mall_product_table");

            entity.HasOne(d => d.ShopRecord).WithMany(p => p.ShoprecordDetails)
                .HasForeignKey(d => d.ShopRecordid)
                .HasConstraintName("FK_shoprecord_detail_shoprecord");
        });

        modelBuilder.Entity<Storedrecord>(entity =>
        {
            entity.HasKey(e => e.StoreRecordId);

            entity.ToTable("storedrecord");

            entity.Property(e => e.StoreRecordId).HasColumnName("store_record_id");
            entity.Property(e => e.GoldDenominationId).HasColumnName("gold_denomination_id");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchase_date");
            entity.Property(e => e.RefundStatus).HasColumnName("refund_status");

            entity.HasOne(d => d.GoldDenomination).WithMany(p => p.Storedrecords)
                .HasForeignKey(d => d.GoldDenominationId)
                .HasConstraintName("FK_storedrecord_gold_exchange_table1");

            entity.HasOne(d => d.Memberunique).WithMany(p => p.Storedrecords)
                .HasForeignKey(d => d.MemberuniqueId)
                .HasConstraintName("FK_storedrecord_basic_member_information");
        });

        modelBuilder.Entity<Tracklist>(entity =>
        {
            entity.ToTable("tracklist");

            entity.Property(e => e.TracklistId).HasColumnName("tracklist_id");
            entity.Property(e => e.MemberuniqueId).HasColumnName("memberunique_id");
            entity.Property(e => e.TrackMemberId).HasColumnName("track_member_id");

            entity.HasOne(d => d.Memberunique).WithMany(p => p.Tracklists)
                .HasForeignKey(d => d.MemberuniqueId)
                .HasConstraintName("FK_tracklist_basic_member_information");
        });

        modelBuilder.Entity<TravelDetail>(entity =>
        {
            entity.HasKey(e => e.TravelDetailsId);

            entity.ToTable("travel_details");

            entity.Property(e => e.TravelDetailsId).HasColumnName("travel_details_id");
            entity.Property(e => e.AccommodationName).HasColumnName("accommodation_Name");
            entity.Property(e => e.Bus).HasColumnName("bus");
            entity.Property(e => e.DinnerName).HasColumnName("dinner_Name");
            entity.Property(e => e.LunchName).HasColumnName("lunch_Name");
            entity.Property(e => e.MorningName).HasColumnName("morning_Name");
            entity.Property(e => e.TourBus).HasColumnName("tour_bus");
            entity.Property(e => e.Train).HasColumnName("train");
            entity.Property(e => e.TravelDetailedIntroduction).HasColumnName("travel_detailed_introduction");
            entity.Property(e => e.TravelId).HasColumnName("travel_id");
            entity.Property(e => e.WhichDay).HasColumnName("which_day");

            entity.HasOne(d => d.Travel).WithMany(p => p.TravelDetails)
                .HasForeignKey(d => d.TravelId)
                .HasConstraintName("FK_travel_details_product_travel1");
        });

        modelBuilder.Entity<TravelTransportationTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("travel_transportation_table");

            entity.Property(e => e.ArrivalDate).HasColumnName("arrival_date");
            entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
            entity.Property(e => e.TransportMode)
                .HasMaxLength(50)
                .HasColumnName("transport_mode");
            entity.Property(e => e.TransportationId).HasColumnName("transportation_id");
        });

        modelBuilder.Entity<TravelareaTable>(entity =>
        {
            entity.HasKey(e => e.TravelareaId).HasName("PK_行程地區");

            entity.ToTable("travelarea_table");

            entity.Property(e => e.TravelareaId).HasColumnName("travelarea_id");
            entity.Property(e => e.TravelareaName)
                .HasMaxLength(50)
                .HasColumnName("travelarea_name");
        });

        modelBuilder.Entity<TravelpicturesTable>(entity =>
        {
            entity.HasKey(e => e.PictureId);

            entity.ToTable("travelpictures_table");

            entity.Property(e => e.PictureId).HasColumnName("picture_id");
            entity.Property(e => e.TravelId).HasColumnName("travel_id");
            entity.Property(e => e.TravelPicture).HasColumnName("travel_picture");

            entity.HasOne(d => d.Travel).WithMany(p => p.TravelpicturesTables)
                .HasForeignKey(d => d.TravelId)
                .HasConstraintName("FK_travelpictures_table_product_travel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
