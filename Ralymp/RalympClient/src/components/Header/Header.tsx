import React, {Component} from 'react'
import {Menu} from 'semantic-ui-react'
// import '../semantic/src/definitiions/semantic.min.css'
export default class Header extends Component {
    state = {activeItem: 'home'};

    handleItemClick = (event: React.MouseEvent<HTMLElement>, {name}: any) => this.setState({activeItem: name});

    render() {
        const {activeItem} = this.state;

        return (

            <Menu pointing secondary>
                <Menu.Item name='home' active={activeItem === 'home'}
                           onClick={this.handleItemClick}
                />
                <Menu.Item
                    name='messages'
                    active={activeItem === 'messages'}
                    onClick={this.handleItemClick}
                />
                <Menu.Item
                    name='friends'
                    active={activeItem === 'friends'}
                    onClick={this.handleItemClick}
                />
                <Menu.Menu position='right'>
                    <Menu.Item
                        name='logout'
                        active={activeItem === 'logout'}
                        onClick={this.handleItemClick}
                    />
                </Menu.Menu>
            </Menu>


        )
    }
}
