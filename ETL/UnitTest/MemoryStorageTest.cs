using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETL.Core.Components.Package;
using ETL.Core.Components.Storage;
using System.Collections.Generic;
using ETL.Core.Components.StorageProvider;
using ETL.Core.Components.SourceComponent;
using ETL.Core.Components.SourceComponent.SourceProviders;

namespace UnitTest {
    [TestClass]
    public class MemoryStorageTest {
        [TestMethod]
        public void CreatePackageUsingMemoryStorageProvider() {
            var pckg = new MemoryPackageStub();
            var stage = new List<IPackageOutputItem>();

            var sourceProvider = pckg.GetSourceProvider();
            var storageProvider = pckg.GetStorageProvider();

            using (var sourceConnection = sourceProvider.EstablishConnection()) {
                foreach (var item in pckg.Extract(sourceProvider))
                    stage.Add(pckg.Transform(item));
            }

            using (var storageConnection = storageProvider.BeginTransaction()) {
                pckg.Load(storageProvider, stage);
                storageProvider.CommitTransaction();
            }
        }
    }


    public class MemoryPackageStub : Package {

        public override ISourceProvider GetSourceProvider() {
            return new MemorySourceProviderStub();
        }

        public override IStorageProvider GetStorageProvider() {
            return new MemoryStorageProvider();
        }

        public override IList<IPackageInputItem> Extract(ISourceProvider provider) {
            return provider.Get();
        }

        public override void Load(IStorageProvider provider, IList<IPackageOutputItem> elements) {
            provider.Save(elements);
        }

        public override IPackageOutputItem Transform(IPackageInputItem element) {
            var item = element as MemoryPackageInputItemStub;
            return new MemoryPackageOutputItemStub() { Id = item.Id + 1 };
        }
    }

    public class MemorySourceProviderStub : MemorySourceProvider {

        public override IList<IPackageInputItem> Get() {
            var source = new List<IPackageInputItem>();
            source.Add(new MemoryPackageInputItemStub() { Id = 1 });
            source.Add(new MemoryPackageInputItemStub() { Id = 2 });
            return source;
        }
    }

    public class MemoryPackageInputItemStub : IPackageInputItem {
        public int Id { get; set; }
    }

    public class MemoryPackageOutputItemStub : IPackageOutputItem {
        public int Id { get; set; }
    }
}
