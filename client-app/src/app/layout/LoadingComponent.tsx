import { Dimmer, Loader } from "semantic-ui-react";

interface Props {
    inverted?: boolean; // giving optional parameter since they are set as default
    content?: string;
}

export default function LoadingComponent({inverted = true, content = 'Loading...'}: Props) {
    return (
        <Dimmer active={true} inverted={inverted}>
            <Loader content={content}/>
        </Dimmer>
    )
}