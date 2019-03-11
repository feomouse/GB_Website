const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
  mode: "development",
  devtool: "inline-source-map",

  module: {
    rules: [{
        test: /\.vue$/,
        use: {
          loader: "vue-loader"
        }
      }, {
        test: /\.css$/,
        use: ["vue-style-loader", "style-loader", 'css-loader']
      }, {
        test: /\.(png|jpg|gif)$/,
        use: [{
          loader: "file-loader",
          options: {}
        }]
      }
      /* , {
              test: /\.js$/,
              enforce: "pre",
              exclude: /ndoe_modules/,
              use: [
                {
                  loader: "jshint-loader",
                  options: {}
                }
              ]
            } */
      , {
        test: /\.less$/,
        use: [{
          loader: "style-loader"
        }, {
          loader: "css-loader"
        }, {
          loader: "less-loader"
        }]
      }
    ]
  },
  resolve: {
    extensions: [".js"]
  }
}