﻿namespace InfoKeeper.Shared.Traits;

public interface IHasCrudOperations<T>
{
    public Task<List<T>> GetAsync();
    public Task<T?> GetAsync(int id);
    public Task<T> CreateAsync(T t);
    public Task<T?> UpdateAsync(T t);
    public Task<T?> DeleteAsync(int id);
}