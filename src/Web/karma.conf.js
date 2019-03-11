const webpack = require('webpack');
const webpackTestConfig = require('./configs/webpack/webpack.test.config.js');

module.exports = function(config) {
  config.set({
    basePath: './',
    frameworks: ['mocha', "chai"],
    port: 44500,
    reporters: ['mocha'],
    browsers: ['PhantomJS'],
    files: ['src/test/test.js'],
    preprocessors: {
      'src/test/test.js': ['webpack']
    },
    webpack: webpackTestConfig,
    plugins: [
      'karma-mocha',
      'karma-chai',
      'karma-webpack',
      'karma-phantomjs-launcher',
      'karma-mocha-reporter'
    ]
  })
}