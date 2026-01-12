using Microsoft.EntityFrameworkCore;
using ShopTARgv24_Ksenia.ApplicationServices.Services;
using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;
using ShopTARgv24_Ksenia.Data;

namespace ShopTARgv24_Ksenia.KindergartenTest
{
    public class KindergartenTest : TestBase
    {
        private KindergartenDto MockDto()
        {
            return new KindergartenDto
            {
                GroupName = "Sunflowers",
                ChildrenCount = 18,
                KindergartenName = "Bright Kids Academy",
                TeacherName = "Anna Petrova",
                CreateAt = DateTime.Now.AddDays(-5),
                UpdateAt = DateTime.Now.AddDays(-5),
                Files = null
            };
        }

        private KindergartenDto MockUpdatedDto(Guid id)
        {
            return new KindergartenDto
            {
                Id = id,
                GroupName = "Sunflowers – Updated",
                ChildrenCount = 20,
                KindergartenName = "Happy Garden",
                TeacherName = "Maria Ivanova",
                CreateAt = DateTime.Now.AddDays(-5),
                UpdateAt = DateTime.Now
            };
        }

        // ----------------------------------------------------------------------
        [Fact]
        public async Task Should_Set_CreateAndUpdateDates_When_NotProvided()
        {

            var dto = MockDto();
            dto.CreateAt = DateTime.MinValue;
            dto.UpdateAt = DateTime.MinValue;

            var result = await Svc<IKindergartensServices>().Create(dto);

            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.NotEqual(DateTime.MinValue, result.CreateAt);
            Assert.NotEqual(DateTime.MinValue, result.UpdateAt);
            Assert.True(result.CreateAt <= DateTime.UtcNow);
            Assert.True(result.UpdateAt <= DateTime.UtcNow);
        }

        // ----------------------------------------------------------------------
        [Fact]
        public async Task Should_ReturnNull_WhenGettingDetailsForNonExistingId()
        {
            // Test kontrollib, et DetailAsync tagastab null,
            // kui antud ID-ga lasteaeda ei eksisteeri.
            var id = Guid.NewGuid();

            var result = await Svc<IKindergartensServices>().DetailAsync(id);

            Assert.Null(result);
        }

        // ----------------------------------------------------------------------
        [Fact]
        public async Task Should_UpdateTeacherName_WithoutChangingGroupName()
        {
            // Test kontrollib, et vaid õpetaja nimi muutub,
            // kuid grupi nimi jääb samaks.
            var dto = MockDto();
            var created = await Svc<IKindergartensServices>().Create(dto);

            Svc<ShopContext>().ChangeTracker.Clear();

            var updateDto = MockUpdatedDto((Guid)created.Id);
            updateDto.GroupName = created.GroupName;   // Grupp jääb samaks

            var updated = await Svc<IKindergartensServices>().Update(updateDto);

            Assert.Equal(created.GroupName, updated.GroupName);
            Assert.NotEqual(created.TeacherName, updated.TeacherName);
        }

        // ----------------------------------------------------------------------
        [Fact]
        public async Task Should_DeleteKindergarten_AndRemoveImages()
        {
            // Test kontrollib, et lasteaed kustutatakse
            // ning seotud pildid eemaldatakse andmebaasist.
            var dto = MockDto();
            var created = await Svc<IKindergartensServices>().Create(dto);

            var deleted = await Svc<IKindergartensServices>().Delete((Guid)created.Id);

            Assert.Equal(created.Id, deleted.Id);

            var files = Svc<ShopContext>().FileToDatabase
                .Where(x => x.KindergartenId == created.Id);

            Assert.Empty(files);
        }

        // ----------------------------------------------------------------------
        [Fact]
        public async Task Should_AllowMultipleUpdates_ToSameEntity()
        {
            // Test kontrollib, et sama objekti saab mitu korda uuendada
            // ning viimane uuendus salvestub korrektselt.
            var dto = MockDto();
            var created = await Svc<IKindergartensServices>().Create(dto);

            Svc<ShopContext>().ChangeTracker.Clear();

            var first = MockUpdatedDto((Guid)created.Id);
            first.TeacherName = "Step 1";
            var result1 = await Svc<IKindergartensServices>().Update(first);

            Svc<ShopContext>().ChangeTracker.Clear();

            var second = MockUpdatedDto((Guid)created.Id);
            second.TeacherName = "Step 2";
            var result2 = await Svc<IKindergartensServices>().Update(second);

            Assert.Equal("Step 2", result2.TeacherName);
        }

        // ----------------------------------------------------------------------
        [Fact]
        public async Task Should_AllowCreatingKindergarten_EvenWithNegativeChildrenCount()
        {
            // Test kontrollib, et negatiivne laste arv ei põhjusta erindit,
            // kuna teenus ei valideeri sisendit.
            var dto = MockDto();
            dto.ChildrenCount = -10;

            var result = await Svc<IKindergartensServices>().Create(dto);

            Assert.NotNull(result);
            Assert.Equal(-10, result.ChildrenCount);
        }
    }
}
