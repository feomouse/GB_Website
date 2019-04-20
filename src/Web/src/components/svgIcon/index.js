import Vue from 'vue'
import SvgIcon from './index.vue'
Vue.component('svg-icon', SvgIcon)

// requires and returns all modules that match
const requireAll = requireContext => requireContext.keys().map(requireContext)
// import all svg
const req = require.context('../../static/svgs', true, /\.svg$/)
requireAll(req)
