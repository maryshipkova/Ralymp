"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var react_1 = require("react");
var react_router_dom_1 = require("react-router-dom");
var Rating_1 = require("../Rating/Rating");
var Home_1 = require("../Home/Home");
var Main = /** @class */ (function (_super) {
    __extends(Main, _super);
    function Main() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Main.prototype.render = function () {
        return (<main className="Main">
                <react_router_dom_1.Switch>
                    <react_router_dom_1.Route exact path='/home' component={Home_1.default}/>
                    <react_router_dom_1.Route exact path='/school' component={Rating_1.default}/>
                    <react_router_dom_1.Route exact path='/teacher' component={Rating_1.default}/>
                    <react_router_dom_1.Route exact path='/student' component={Rating_1.default}/>
                    <react_router_dom_1.Route exact path='/subject' component={Rating_1.default}/>
                    <react_router_dom_1.Route path="*" exact component={Home_1.default}/>
                </react_router_dom_1.Switch>
            </main>);
    };
    return Main;
}(react_1.Component));
exports.default = Main;
