﻿namespace FS.Abp.JobsManagement.MongoDB
{
    /* This class can be used as a base class for MongoDB integration tests,
     * while SampleRepository_Tests uses a different approach.
     */
    public abstract class JobsManagementMongoDbTestBase : JobsManagementTestBase<JobsManagementMongoDbTestModule>
    {

    }
}