namespace ResumeProfile.Infrastructure.Common
{
    public static class Extensions
    {
        public static void OnCreated(this ModelBuilder modelBuilder)
        {
            var ListICreatedEntities = typeof(ICreatedEntity).GetAllClassName();

            var ListMapEntities = modelBuilder.Model.GetEntityTypes().Where(x => ListICreatedEntities.Contains(x.ClrType.FullName));
            foreach (var EntityMap in ListMapEntities)
            {
                var prop = EntityMap.FindProperty("CreatedByUserId");
                if (prop == null)
                {
                    EntityMap.AddProperty("CreatedDateTime", typeof(DateTime?)).IsColumnNullable();
                    EntityMap.FindProperty("CreatedDateTime").ValueGenerated = ValueGenerated.OnAdd;
                    EntityMap.FindProperty("CreatedDateTime").SetDefaultValueSql("GETDATE()");
                    EntityMap.AddProperty("CreatedByUserId", typeof(long?)).IsColumnNullable();
                    EntityMap.AddProperty("CreatedByIP", typeof(string)).IsColumnNullable();
                }
            }
        }

        public static void OnModified(this ModelBuilder modelBuilder)
        {
            var ListIModifiedEntities = typeof(IModifiedEntity).GetAllClassName();

            var ListMapEntities = modelBuilder.Model.GetEntityTypes().Where(x => ListIModifiedEntities.Contains(x.ClrType.FullName));
            foreach (var EntityMap in ListMapEntities)
            {
                var prop = EntityMap.FindProperty("ModifiedByUserId");
                if (prop == null)
                {
                    EntityMap.AddProperty("ModifiedDateTime", typeof(DateTime?)).IsColumnNullable();
                    EntityMap.AddProperty("ModifiedByUserId", typeof(long?)).IsColumnNullable();
                    EntityMap.AddProperty("ModifiedByIP", typeof(string)).IsColumnNullable();
                }
            }
        }

        public static void OnDeleted(this ModelBuilder modelBuilder)
        {
            var ListISoftDeletedEntities = typeof(ISoftDeleted).GetAllClassName();

            var ListMapEntities = modelBuilder.Model.GetEntityTypes().Where(x => ListISoftDeletedEntities.Contains(x.ClrType.FullName));
            foreach (var EntityMap in ListMapEntities)
            {
                var prop = EntityMap.FindProperty("DeletedByUserId");
                if (prop == null)
                {
                    EntityMap.AddProperty("DeletedDateTime", typeof(DateTime?)).IsColumnNullable();
                    EntityMap.AddProperty("DeletedByUserId", typeof(long?)).IsColumnNullable();
                    EntityMap.AddProperty("DeletedByIP", typeof(string)).IsColumnNullable();
                    EntityMap.AddProperty("IsDeleted", typeof(bool)).SetDefaultValue(false);
                }
            }
        }
    }
}