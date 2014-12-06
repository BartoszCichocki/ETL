using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETL.Core.Components.Package;
using ETL.Core.Components.Storage;
using System.Collections.Generic;
using ETL.Core.Components.StorageProvider;

namespace UnitTest {
    [TestClass]
    public class MemoryStorageTest {
        [TestMethod]
        public void CreatePackageUsingMemoryStorageProvider() {
            var pckg = new MemoryPackageStub();

            var inputStorageProvider = pckg.GetInputStorageProvider();
            // make transaction etc...







            IList<MemoryPackageOutputItemStub> batch = new List<MemoryPackageOutputItemStub>();
            foreach (var item in pckg.Extract(inputStorageProvider))
               batch.Add(pckg.Transform(item) as MemoryPackageOutputItemStub);

            //pckg.Load(batch);

        }
    }

    public class MemoryPackageStub : Package {
        private IStorageProvider provider = new MemmoryStorageProvider();

        public override IStorageProvider GetInputStorageProvider() { return provider; }
        public override IStorageProvider GetOutputStorageProvider() { return provider; }

        public override IList<IPackageInputItem> Extract(IStorageProvider provider) {
            return provider.Get<MemoryPackageInputItemStub>() as List<IPackageInputItem>;
        }

        public override void Load(IList<IPackageOutputItem> elements) {
            provider.Put<IPackageOutputItem>(elements);
        }

        public override IPackageOutputItem Transform(IPackageInputItem element) {
            var item = element as MemoryPackageInputItemStub;
            return new MemoryPackageOutputItemStub() {
                Id = item.Id + 1
            };
        }
    }

    public class MemoryPackageInputItemStub : IPackageInputItem {
        public int Id { get; set; }
    }

    public class MemoryPackageOutputItemStub : IPackageOutputItem {
        public int Id { get; set; }
    }
}
