const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  mode: "development",
  entry: {
    index: "./src/main"
  },
  devtool: "inline-source-map",
  output: {
    path: path.resolve(__dirname, "dist"),

    filename: "[name].js"
  },
  devtool: 'inline-source-map',

  module: {
    rules: [
      {
        test: /\.vue$/,
        use: {
          loader: "vue-loader"
        }
      }, {
        test: /\.js$/,
        exclude: /(ndoe_modules|bower_components)/,
        use: {
          loader: "babel-loader",
          options: {
            presets: ["@babel/preset-env"]
          }
        }
      }, {
        test: /\.css$/,
        use: ["vue-style-loader", "style-loader", 'css-loader']
      }, {
        test: /\.(png|jpg|jpeg|gif|woff|ttf)$/,
        use: [
          {
            loader: "file-loader",
            options: {}
          }
        ]
      }/* , {
        test: /\.js$/,
        enforce: "pre",
        exclude: /ndoe_modules/,
        use: [
          {
            loader: "jshint-loader",
            options: {}
          }
        ]
      } */, {
        test: /\.less$/,
        use: [{
          loader: "vue-style-loader"
        }, {
          loader: "css-loader"
        }, {
          loader: "less-loader"
        }]
      }, {
        test: /test\.js$/,
        use: "mocha-loader",
        exclude: /ndoe_modules/
      }
    ]
  },
  plugins: [
    new VueLoaderPlugin(),
    new HtmlWebpackPlugin({
      filename: "index.html",
      template: "index.html",
      inject: 'true'
    })
  ],
  resolve: {
    extensions: [".js", ".vue", ".less"],
    alias: {
      'vue$': 'vue/dist/vue.esm.js'
    }
  },
  devServer: {
    contentBase: path.join(__dirname, "../../"),
    compress: true,
    host: "localhost",
    port: 55000,
    hot: true,
    proxy: {
      "/": "http://localhost:5000/"
    }
  }
}