using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageProcessing
{
    public static class ParallelFilteringItems
    {
        public delegate void ProcessingImageHandler();
        //public static event ProcessingImageHandler imageProcessingCompleted;
        public static event ProcessingImageHandler allImagesProcessingCompleted;
        public static List<Task> Workers;
        public static ImageItem[] ImageItems;
        public static FilterPlugin[] Filters;

        public static async Task ProcessImages()
        {
            Workers = new List<Task>();
            TaskFactory taskFactory = new TaskFactory();

            for (int i = 0; i < ImageItems.Length; i++)
            {
                ImageItems[i].FilterPlugins = Filters;
                //imageItems[i].ApplyFilters();
                Workers.Add(taskFactory.StartNew(ImageItems[i].ApplyFilters));
            }

            await Task.WhenAll(Workers.ToArray());
            allImagesProcessingCompleted?.Invoke();
            allImagesProcessingCompleted = null;
        }

        public static bool IsCompleted()
        {
            foreach (var worker in Workers)
            {
                if (!worker.IsCompleted)
                    return false;
            }

            return true;
        }
    }
}
