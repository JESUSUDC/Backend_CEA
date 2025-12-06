
using Domain.Cellphones.Entity;
using Domain.Generics;

namespace Domain.Users.Entity
{
    public class User : GenericEntity<UserId>
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }

        private readonly HashSet<Cellphone> _cellphones = new();
        public IReadOnlyCollection<Cellphone> Cellphones => _cellphones;

        public User(UserId id, string name, string lastName, string userName, string passwordHash)
            : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UserName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = userName ?? throw new ArgumentNullException(nameof(userName));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        }

        public void Update(string name, string lastName, string userName, string passwordHash)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            UpdateAt = DateTime.Now;
        }

        public void AddCellphone(Cellphone cellphone)
        {
            if (cellphone == null) throw new ArgumentNullException(nameof(cellphone));
            _cellphones.Add(cellphone);
            UpdateAt = DateTime.Now;
        }

        public void RemoveCellphone(Cellphone cellphone)
        {
            if (cellphone == null) throw new ArgumentNullException(nameof(cellphone));
            _cellphones.Remove(cellphone);
            UpdateAt = DateTime.Now;
        }

    }
}
