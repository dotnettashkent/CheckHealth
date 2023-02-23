using CheckHealth.DAL.Configrations;
using CheckHealth.DAL.IRepositories;
using CheckHealth.Domain.Commons;
using CheckHealth.Domain.Entities;
using Newtonsoft.Json;

namespace CheckHealth.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Auditable
    {
        private string Path;
        private long LastId = 0;

        public GenericRepository()
        {
            StartUp();
        }

        private async void StartUp()
        {
            if (typeof(TEntity) == typeof(User))
            {
                Path = DatabasePaths.ALL_USERS;
            }
            else if (typeof(TEntity) == typeof(UserIsNotPremium))
            {
                Path = DatabasePaths.USER_IS_NOT_PREMIUM;
            }
            else if (typeof(TEntity) == typeof(UserPremium))
            {
                Path = DatabasePaths.USER_PREMIUM;
            }
            foreach (var model in await GetAllAsync())
            {
                if (model.Id > LastId)
                    LastId = model.Id;
            }
        }


        public async Task<TEntity> CreateAsync(TEntity model)
        {
            model.Id = ++LastId;
            var models = await GetAllAsync();
            models.Add(model);

            File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

            return model;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            List<TEntity> models = await GetAllAsync();
            var model = models.FirstOrDefault(x => x.Id == id);
            if (model is null)
            {
                return false;
            }

            models.Remove(model);

            File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));
            return true;
        }

        public async Task<List<TEntity>> GetAllAsync(Predicate<TEntity> predicate = null)
        {
            string text = File.ReadAllText(Path);
            if (string.IsNullOrEmpty(text))
            {
                text = "[]";
            }

            var result = JsonConvert.DeserializeObject<List<TEntity>>(text);

            if (predicate is null)
                return result;

            return result.FindAll(predicate);
        }

        public async Task<TEntity> GetAsync(long id)
        {
            return (await GetAllAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            var models = await GetAllAsync();
            var updatingModel = models.FirstOrDefault(x => x.Id == model.Id);

            if (updatingModel == null)
                return null;

            int index = models.IndexOf(updatingModel);

            models.Remove(updatingModel);

            model.CreatedAt = updatingModel.CreatedAt;
            models.Insert(index, model);

            File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

            return model;
        }
    }
}
