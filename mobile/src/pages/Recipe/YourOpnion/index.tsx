import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { RecipeStack } from '../../../interface/IRoutes';

const YourOpnion: React.FC<StackScreenProps<RecipeStack, 'YourOpnion'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> YourOpnion</Text>
      </View>
    </>
  );
};

export default YourOpnion;
