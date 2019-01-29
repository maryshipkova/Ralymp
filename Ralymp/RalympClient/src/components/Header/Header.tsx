import React, {Component} from 'react'
import {Menu} from 'semantic-ui-react'
import {Link} from 'react-router-dom'

type Props = {};
type State = { activeItem: string };
export default class Header extends Component<Props, State> {
    state = {activeItem: ''};

    handleItemClick = (event: React.MouseEvent<HTMLElement>, {name}: any) => this.setState({activeItem: name});

    render() {
        const {activeItem} = this.state;

        return (

            <Menu pointing secondary>
                <Link to='/home'>
                    <Menu.Item
                        name='home'
                        active={activeItem === 'home'}
                        onClick={this.handleItemClick}
                    />
                </Link>
                <Link to='/school'>
                    <Menu.Item
                        name='school'
                        active={activeItem === 'school'}
                        onClick={this.handleItemClick}
                    />
                </Link>
                <Link to='/teacher'>
                    <Menu.Item
                        name='teacher'
                        active={activeItem === 'teacher'}
                        onClick={this.handleItemClick}
                    />
                </Link>
                <Link to='/student'><Menu.Item
                    name='student'
                    active={activeItem === 'student'}
                    onClick={this.handleItemClick}
                />
                </Link>
                <Link to='/subject'>
                    <Menu.Item
                        name='subject'
                        active={activeItem === 'subject'}
                        onClick={this.handleItemClick}
                    />
                </Link>
            </Menu>
        )
    }
}
