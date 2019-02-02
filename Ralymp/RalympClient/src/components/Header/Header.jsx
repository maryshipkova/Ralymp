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
var semantic_ui_react_1 = require("semantic-ui-react");
var react_router_dom_1 = require("react-router-dom");
var Header = /** @class */ (function (_super) {
    __extends(Header, _super);
    function Header() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.state = { activeItem: '' };
        _this.handleItemClick = function (event, _a) {
            var name = _a.name;
            return _this.setState({ activeItem: name });
        };
        return _this;
    }
    Header.prototype.render = function () {
        var activeItem = this.state.activeItem;
        return (<semantic_ui_react_1.Menu pointing secondary>
                <react_router_dom_1.Link to='/home'>
                    <semantic_ui_react_1.Menu.Item name='home' active={activeItem === 'home'} onClick={this.handleItemClick}/>
                </react_router_dom_1.Link>
                <react_router_dom_1.Link to='/school'>
                    <semantic_ui_react_1.Menu.Item name='school' active={activeItem === 'school'} onClick={this.handleItemClick}/>
                </react_router_dom_1.Link>
                <react_router_dom_1.Link to='/teacher'>
                    <semantic_ui_react_1.Menu.Item name='teacher' active={activeItem === 'teacher'} onClick={this.handleItemClick}/>
                </react_router_dom_1.Link>
                <react_router_dom_1.Link to='/student'><semantic_ui_react_1.Menu.Item name='student' active={activeItem === 'student'} onClick={this.handleItemClick}/>
                </react_router_dom_1.Link>
                <react_router_dom_1.Link to='/subject'>
                    <semantic_ui_react_1.Menu.Item name='subject' active={activeItem === 'subject'} onClick={this.handleItemClick}/>
                </react_router_dom_1.Link>
            </semantic_ui_react_1.Menu>);
    };
    return Header;
}(react_1.Component));
exports.default = Header;
