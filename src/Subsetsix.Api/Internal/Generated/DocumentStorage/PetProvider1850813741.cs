// <auto-generated/>
#pragma warning disable
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Npgsql;
using Subsetsix.Api;
using System;
using System.Collections.Generic;
using Weasel.Core;
using Weasel.Postgresql;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertPetOperation1850813741
    public class UpsertPetOperation1850813741 : Marten.Internal.Operations.StorageOperation<Subsetsix.Api.Pet, System.Guid>
    {
        private readonly Subsetsix.Api.Pet _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertPetOperation1850813741(Subsetsix.Api.Pet document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_pet(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: UpsertPetOperation1850813741
    
    
    // START: InsertPetOperation1850813741
    public class InsertPetOperation1850813741 : Marten.Internal.Operations.StorageOperation<Subsetsix.Api.Pet, System.Guid>
    {
        private readonly Subsetsix.Api.Pet _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertPetOperation1850813741(Subsetsix.Api.Pet document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_pet(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: InsertPetOperation1850813741
    
    
    // START: UpdatePetOperation1850813741
    public class UpdatePetOperation1850813741 : Marten.Internal.Operations.StorageOperation<Subsetsix.Api.Pet, System.Guid>
    {
        private readonly Subsetsix.Api.Pet _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdatePetOperation1850813741(Subsetsix.Api.Pet document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_update_pet(?, ?, ?, ?)";


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }

    }

    // END: UpdatePetOperation1850813741
    
    
    // START: QueryOnlyPetSelector1850813741
    public class QueryOnlyPetSelector1850813741 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<Subsetsix.Api.Pet>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyPetSelector1850813741(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Subsetsix.Api.Pet Resolve(System.Data.Common.DbDataReader reader)
        {

            Subsetsix.Api.Pet document;
            document = _serializer.FromJson<Subsetsix.Api.Pet>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<Subsetsix.Api.Pet> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            Subsetsix.Api.Pet document;
            document = await _serializer.FromJsonAsync<Subsetsix.Api.Pet>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyPetSelector1850813741
    
    
    // START: LightweightPetSelector1850813741
    public class LightweightPetSelector1850813741 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<Subsetsix.Api.Pet, System.Guid>, Marten.Linq.Selectors.ISelector<Subsetsix.Api.Pet>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightPetSelector1850813741(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Subsetsix.Api.Pet Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);

            Subsetsix.Api.Pet document;
            document = _serializer.FromJson<Subsetsix.Api.Pet>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Subsetsix.Api.Pet> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);

            Subsetsix.Api.Pet document;
            document = await _serializer.FromJsonAsync<Subsetsix.Api.Pet>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightPetSelector1850813741
    
    
    // START: IdentityMapPetSelector1850813741
    public class IdentityMapPetSelector1850813741 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<Subsetsix.Api.Pet, System.Guid>, Marten.Linq.Selectors.ISelector<Subsetsix.Api.Pet>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapPetSelector1850813741(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Subsetsix.Api.Pet Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Subsetsix.Api.Pet document;
            document = _serializer.FromJson<Subsetsix.Api.Pet>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<Subsetsix.Api.Pet> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Subsetsix.Api.Pet document;
            document = await _serializer.FromJsonAsync<Subsetsix.Api.Pet>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapPetSelector1850813741
    
    
    // START: DirtyTrackingPetSelector1850813741
    public class DirtyTrackingPetSelector1850813741 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<Subsetsix.Api.Pet, System.Guid>, Marten.Linq.Selectors.ISelector<Subsetsix.Api.Pet>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingPetSelector1850813741(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public Subsetsix.Api.Pet Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Subsetsix.Api.Pet document;
            document = _serializer.FromJson<Subsetsix.Api.Pet>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<Subsetsix.Api.Pet> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            Subsetsix.Api.Pet document;
            document = await _serializer.FromJsonAsync<Subsetsix.Api.Pet>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingPetSelector1850813741
    
    
    // START: QueryOnlyPetDocumentStorage1850813741
    public class QueryOnlyPetDocumentStorage1850813741 : Marten.Internal.Storage.QueryOnlyDocumentStorage<Subsetsix.Api.Pet, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyPetDocumentStorage1850813741(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Subsetsix.Api.Pet document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdatePetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertPetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertPetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Subsetsix.Api.Pet document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyPetSelector1850813741(session, _document);
        }

    }

    // END: QueryOnlyPetDocumentStorage1850813741
    
    
    // START: LightweightPetDocumentStorage1850813741
    public class LightweightPetDocumentStorage1850813741 : Marten.Internal.Storage.LightweightDocumentStorage<Subsetsix.Api.Pet, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightPetDocumentStorage1850813741(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Subsetsix.Api.Pet document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdatePetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertPetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertPetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Subsetsix.Api.Pet document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightPetSelector1850813741(session, _document);
        }

    }

    // END: LightweightPetDocumentStorage1850813741
    
    
    // START: IdentityMapPetDocumentStorage1850813741
    public class IdentityMapPetDocumentStorage1850813741 : Marten.Internal.Storage.IdentityMapDocumentStorage<Subsetsix.Api.Pet, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapPetDocumentStorage1850813741(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Subsetsix.Api.Pet document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdatePetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertPetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertPetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Subsetsix.Api.Pet document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapPetSelector1850813741(session, _document);
        }

    }

    // END: IdentityMapPetDocumentStorage1850813741
    
    
    // START: DirtyTrackingPetDocumentStorage1850813741
    public class DirtyTrackingPetDocumentStorage1850813741 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<Subsetsix.Api.Pet, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingPetDocumentStorage1850813741(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(Subsetsix.Api.Pet document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdatePetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertPetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertPetOperation1850813741
            (
                document, Identity(document),
                session.Versions.ForType<Subsetsix.Api.Pet, System.Guid>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(Subsetsix.Api.Pet document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(Subsetsix.Api.Pet document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingPetSelector1850813741(session, _document);
        }

    }

    // END: DirtyTrackingPetDocumentStorage1850813741
    
    
    // START: PetBulkLoader1850813741
    public class PetBulkLoader1850813741 : Marten.Internal.CodeGeneration.BulkLoader<Subsetsix.Api.Pet, System.Guid>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<Subsetsix.Api.Pet, System.Guid> _storage;

        public PetBulkLoader1850813741(Marten.Internal.Storage.IDocumentStorage<Subsetsix.Api.Pet, System.Guid> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_pet(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_pet_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_pet (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_pet_temp.\"id\", mt_doc_pet_temp.\"data\", mt_doc_pet_temp.\"mt_version\", mt_doc_pet_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_pet_temp left join public.mt_doc_pet on mt_doc_pet_temp.id = public.mt_doc_pet.id where public.mt_doc_pet.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_pet target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_pet_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_pet_temp as select * from public.mt_doc_pet limit 0";


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, Subsetsix.Api.Pet document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, Subsetsix.Api.Pet document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }

    }

    // END: PetBulkLoader1850813741
    
    
    // START: PetProvider1850813741
    public class PetProvider1850813741 : Marten.Internal.Storage.DocumentProvider<Subsetsix.Api.Pet>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public PetProvider1850813741(Marten.Schema.DocumentMapping mapping) : base(new PetBulkLoader1850813741(new QueryOnlyPetDocumentStorage1850813741(mapping)), new QueryOnlyPetDocumentStorage1850813741(mapping), new LightweightPetDocumentStorage1850813741(mapping), new IdentityMapPetDocumentStorage1850813741(mapping), new DirtyTrackingPetDocumentStorage1850813741(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: PetProvider1850813741
    
    
}

