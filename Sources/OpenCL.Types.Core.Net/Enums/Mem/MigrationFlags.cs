using System;

namespace OpenCL.Types.Core.Net.Enums.Mem
{
    /* 1.2 */
    // cl_mem_migration_flags - bitfield
    [Flags]
    public enum MemMigrationFlags : ulong
    {
        Host = 1 << 0,
        ContentUndefined = 1 << 1
    }
}