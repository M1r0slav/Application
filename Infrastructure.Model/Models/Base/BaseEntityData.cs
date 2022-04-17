namespace Infrastructure.Models
{
    using System;
    public abstract class BaseEntityData
    {
        private bool isDeleted = false;
        protected BaseEntityData()
        {
            DateOfCreation = DateTime.UtcNow;
            isDeleted = false;
            DateOfDeletion = null;
        }
        public DateTime DateOfCreation { get; set; }
        public DateTime? DateOfDeletion { get; private set; }
        public bool IsDeleted
        {
            get => isDeleted;
            set
            {
                if (value == isDeleted)
                {
                    return;
                }
                if (value == true)
                {
                    this.DateOfDeletion = DateTime.UtcNow;
                }
                else
                {
                    this.DateOfDeletion = null;
                }
                isDeleted = value;
            }
        }
    }
}