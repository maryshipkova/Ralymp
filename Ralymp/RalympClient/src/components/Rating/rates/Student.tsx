import React, {Component} from 'react'
import {IStudent} from "../../../models/Student";

type Props = { students: IStudent[] };
type State = {};
export default class Student extends Component<Props, State> {
    render() {
        const {students} = this.props;
        return (<ul>
            {students.map((student: IStudent) =>
                <li key={student.studentName}>
                    {student.studentName + '  ' + student.schoolTitle}
                </li>
            )}
        </ul>);
    }
}

