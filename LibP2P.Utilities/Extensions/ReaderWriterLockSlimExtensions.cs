using System;
using System.Threading;

namespace LibP2P.Utilities.Extensions
{
    public static class ReaderWriterLockSlimExtensions
    {
        public static T Read<T>(this ReaderWriterLockSlim rw, Func<T> func)
        {
            rw.EnterReadLock();
            try
            {
                return func();
            }
            finally 
            {
                rw.ExitReadLock();
            }
        }

        public static void Read(this ReaderWriterLockSlim rw, Action action)
        {
            rw.EnterReadLock();
            try
            {
                action();
            }
            finally
            {
                rw.ExitReadLock();
            }
        }

        public static T Write<T>(this ReaderWriterLockSlim rw, Func<T> func)
        {
            rw.EnterWriteLock();
            try
            {
                return func();
            }
            finally
            {
                rw.ExitWriteLock();
            }
        }

        public static void Write(this ReaderWriterLockSlim rw, Action action)
        {
            rw.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                rw.ExitWriteLock();
            }
        }
    }
}