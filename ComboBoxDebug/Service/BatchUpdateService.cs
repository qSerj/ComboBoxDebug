namespace ComboBoxDebug.Service;

using System;

public class BatchUpdateService : IDisposable
{
    private int _batchLevel = 0;
    public bool IsBatch => _batchLevel > 0;

    public IDisposable BeginBatch()
    {
        _batchLevel++;
        return this;
    }

    public void Dispose()
    {
        _batchLevel = Math.Max(0, _batchLevel - 1);
    }
}