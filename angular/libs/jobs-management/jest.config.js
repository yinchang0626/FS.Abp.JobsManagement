module.exports = {
  name: 'jobs-management',
  preset: '../../jest.config.js',
  coverageDirectory: '../../coverage/libs/jobs-management',
  snapshotSerializers: [
    'jest-preset-angular/AngularSnapshotSerializer.js',
    'jest-preset-angular/HTMLCommentSerializer.js'
  ]
};
