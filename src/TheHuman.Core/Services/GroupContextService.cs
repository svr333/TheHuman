using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TheHuman.Core
{
    public class GroupContextService
    {
        private ConcurrentDictionary<ulong, ulong> _users = new ConcurrentDictionary<ulong, ulong>();
        
        public ConcurrentDictionary<ulong, ulong> Users => _users;

        public GroupContextService()
        {
            _users.TryAdd(0, 0);
        }

        public bool UserHasContext(ulong userId)
            => _users.ContainsKey(userId);

        public bool TryGetUserContext(ulong userId, out ulong groupId)
            => _users.TryGetValue(userId, out groupId);

        public bool TrySetUserContext(ulong userId, ulong groupId, out ulong oldGroupId)
        {
            oldGroupId = 0;
            var succeeded = false;
            
            if (UserHasContext(userId)) succeeded = _users.TryRemove(userId, out oldGroupId);

            succeeded = _users.TryAdd(userId, groupId);
            return succeeded;
        }
    }
}
