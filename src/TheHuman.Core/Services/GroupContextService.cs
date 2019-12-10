using System.Collections.Concurrent;

namespace TheHuman.Core
{
    public class GroupContextService
    {
        private ConcurrentDictionary<ulong, ulong> _users = new ConcurrentDictionary<ulong, ulong>();
        
        public ConcurrentDictionary<ulong, ulong> Users => _users;

        public bool UserHasContext(ulong userId)
        => _users.ContainsKey(userId);

        public bool TryGetUserContext(ulong userId, out ulong groupId)
            => _users.TryGetValue(userId, out groupId);

        public bool TrySetUserContext(ulong userId, ulong groupId)
            => _users.TryAdd(userId, groupId);
    }
}
