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
        const navItems = ['home', 'school', 'teacher', 'student', 'subject'];
        const navColor = 'violet';

        return (
            <Menu inverted>
                {navItems.map(item => (
                    <Link to={`/${item}`}>
                        <Menu.Item
                            name={item}
                            active={activeItem === item}
                            onClick={this.handleItemClick}
                            color={navColor}
                        />
                    </Link>
                ))}

            </Menu>
        )
    }
}
